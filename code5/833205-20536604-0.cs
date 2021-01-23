    using System;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;
    
    namespace WinRTDatePicker
    {
        [TemplatePart(Name = "_DayOptions", Type = typeof(ComboBox))]
        [TemplatePart(Name = "_MonthOptions", Type = typeof(ComboBox))]
        [TemplatePart(Name = "_YearOptions", Type = typeof(ComboBox))]
        public sealed class DatePicker : Control
        {
            public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(DatePicker), new PropertyMetadata(default(DateTime?), SelectedDateChangedCallback));
            public static readonly DependencyProperty DayOptionFormatProperty = DependencyProperty.Register("DayOptionFormat", typeof(string), typeof(DatePicker), new PropertyMetadata(default(string)));
            public static readonly DependencyProperty MonthOptionFormatProperty = DependencyProperty.Register("MonthOptionFormat", typeof(string), typeof(DatePicker), new PropertyMetadata(default(string)));
    
            public event EventHandler<SelectedDateChangedEventArgs> SelectedDateChanged; 
    
            private readonly ObservableCollection<string> daysInRange = new ObservableCollection<string>();
            private readonly ObservableCollection<string> monthsInRange = new ObservableCollection<string>();
            private readonly ObservableCollection<string> yearsInRange = new ObservableCollection<string>();
    
            public DatePicker()
            {
                DefaultStyleKey = typeof(DatePicker);
    
                //SelectedDate = DateTime.Today;
                DayOptionFormat = "dd dddd";
                MonthOptionFormat = "MMMM";
            }
    
            protected override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                monthsInRange.Clear();
                monthsInRange.Add("Month");
                for (int i = 1; i <= 12; i++)
                {
                    DateTime monthStart = new DateTime(DateTime.Now.Year, i, 1);
                    monthsInRange.Add(monthStart.ToString(MonthOptionFormat));
                }
    
                CreateBindings();
                SetSelectedDate(SelectedDate);
    
                DayOptions.SelectionChanged += DayOptionsOnSelectionChanged;
                MonthOptions.SelectionChanged += MonthOptionsOnSelectionChanged;
                YearOptions.SelectionChanged += YearOptionsOnSelectionChanged;
            }
    
            private void SetSelectedDate(DateTime? newSelectedDate)
            {
                if (DayOptions != null && MonthOptions != null && YearOptions != null)
                {
                    var TempNewSelectedDate = newSelectedDate;
                    if (newSelectedDate == null)
                    {
                        newSelectedDate = DateTime.Today;
                    }
                    daysInRange.Clear();
                    yearsInRange.Clear();
    
                    daysInRange.Add("Date");
                    for (int i = 1; i <= DateTime.DaysInMonth(newSelectedDate.Value.Year, newSelectedDate.Value.Month); i++)
                    {
                        DateTime date = new DateTime(newSelectedDate.Value.Year, newSelectedDate.Value.Month, i);
                        daysInRange.Add(date.ToString(DayOptionFormat));
                    }
    
                    int minYear = newSelectedDate.Value.Year - 10;
                    int maxYear = newSelectedDate.Value.Year + 10;
    
                    yearsInRange.Add("Year");
                    for (int i = minYear; i <= maxYear; i++)
                    {
                        yearsInRange.Add(i.ToString());
                    }
    
                    if (TempNewSelectedDate != null)
                    {
                        DayOptions.SelectedIndex = newSelectedDate.Value.Day;
                        MonthOptions.SelectedIndex = newSelectedDate.Value.Month;
                        YearOptions.SelectedItem = newSelectedDate.Value.Year.ToString();
                    }
    
                    else
                    {
                        DayOptions.SelectedIndex = 0;
                        MonthOptions.SelectedIndex = 0;
                        YearOptions.SelectedIndex = 0;
                    }
                }
            }
    
            private void CreateBindings()
            {
                Binding dayOptionsBinding = new Binding { Source = daysInRange, Mode = BindingMode.OneWay };
                DayOptions.SetBinding(ItemsControl.ItemsSourceProperty, dayOptionsBinding);
    
                Binding monthOptionsBinding = new Binding { Source = monthsInRange, Mode = BindingMode.OneWay };
                MonthOptions.SetBinding(ItemsControl.ItemsSourceProperty, monthOptionsBinding);
                
                Binding yearOptionsBinding = new Binding { Source = yearsInRange, Mode = BindingMode.OneWay };
                YearOptions.SetBinding(ItemsControl.ItemsSourceProperty, yearOptionsBinding);
            }
    
            private void UpdateSelectedDateFromInputs()
            {
                if (YearOptions.SelectedIndex > 0 && MonthOptions.SelectedIndex > 0 && DayOptions.SelectedIndex > 0)
                {
                    int year = int.Parse(YearOptions.SelectedValue.ToString());
                    int month = MonthOptions.SelectedIndex;
                    int day = DayOptions.SelectedIndex;
    
                    int maxDaysInMonth = DateTime.DaysInMonth(year, month);
                    if (day > maxDaysInMonth)
                    {
                        day = maxDaysInMonth;
                        DayOptions.SelectedIndex = maxDaysInMonth - 1;
                    }
    
                    if (month == 0)
                        month = 1;
    
                    if (day == 0)
                        day = 1;
    
                    SelectedDate = new DateTime(year, month, day);
                }
                else if (YearOptions.SelectedIndex == 0 && MonthOptions.SelectedIndex == 0 && DayOptions.SelectedIndex == 0)
                {
                    SelectedDate = null;
                }
            }
    
            private void UpdateDayOptions()
            {
                if (SelectedDate != null)
                {
                    int selectedDayIndex = DayOptions.SelectedIndex;
                    int month = MonthOptions.SelectedIndex;
    
                    if (month != 0)
                    {
                        daysInRange.Clear();
                        daysInRange.Add("Date");
                        for (int i = 1; i <= DateTime.DaysInMonth(SelectedDate.Value.Year, month); i++)
                        {
                            DateTime date = new DateTime(SelectedDate.Value.Year, month, i);
                            daysInRange.Add(date.ToString(DayOptionFormat));
                        }
    
                        DayOptions.SelectedIndex = selectedDayIndex;  
                    }
                }
            }
    
            private void DayOptionsOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
            {
                UpdateSelectedDateFromInputs();
            }
    
            private void MonthOptionsOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
            {
                UpdateSelectedDateFromInputs();
                UpdateDayOptions();
            }
    
            private void YearOptionsOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
            {
                UpdateSelectedDateFromInputs();
                UpdateDayOptions();
            }
    
            private static void SelectedDateChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
            {
                DateTime oldValue = args.OldValue != null ? (DateTime)args.OldValue : DateTime.Today.AddDays(-1);
                DateTime? newValue = (DateTime?)args.NewValue;
    
                if (newValue != oldValue)
                {
                    DatePicker datePicker = (DatePicker)obj;
                    datePicker.SetSelectedDate(newValue);
    
                    if (datePicker.SelectedDateChanged != null)
                        datePicker.SelectedDateChanged(datePicker, new SelectedDateChangedEventArgs(newValue));
                }
            }
    
            public DateTime? SelectedDate
            {
                get { return (DateTime?)GetValue(SelectedDateProperty); }
                set { SetValue(SelectedDateProperty, value); }
            }
    
            public string DayOptionFormat
            {
                get { return (string)GetValue(DayOptionFormatProperty); }
                set { SetValue(DayOptionFormatProperty, value); }
            }
    
            public string MonthOptionFormat
            {
                get { return (string)GetValue(MonthOptionFormatProperty); }
                set { SetValue(MonthOptionFormatProperty, value); }
            }
    
            private ComboBox DayOptions
            {
                get { return (ComboBox)GetTemplateChild("_DayOptions"); }
            }
    
            private ComboBox MonthOptions
            {
                get { return (ComboBox)GetTemplateChild("_MonthOptions"); }
            }
    
            private ComboBox YearOptions
            {
                get { return (ComboBox)GetTemplateChild("_YearOptions"); }
            }
        }
    }
    using System;
    
    namespace WinRTDatePicker
    {
        public class SelectedDateChangedEventArgs : EventArgs
        {
            private readonly DateTime? newDate;
    
            public SelectedDateChangedEventArgs(DateTime? newDate)
            {
                this.newDate = newDate;
            }
    
            public DateTime? NewDate
            {
                get { return newDate; }
            }
        }
    }

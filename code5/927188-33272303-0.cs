    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;
    
    namespace MyApp.Views
    {
        public sealed partial class DateTimePickerControl : UserControl
        {
            public static readonly DependencyProperty SelectedDateTimeProperty =
                DependencyProperty.Register("SelectedDateTime", typeof (DateTime), typeof (DateTimePickerControl), new PropertyMetadata(DateTime.Now));
    
            public static readonly DependencyProperty SelectedDateProperty =
                DependencyProperty.Register("SelectedDate", typeof (DateTimeOffset), typeof (DateTimePickerControl), new PropertyMetadata(DateTimeOffset.Now, OnDateChanged));
    
            public static readonly DependencyProperty SelectedTimeProperty =
                DependencyProperty.Register("SelectedTime", typeof (TimeSpan), typeof (DateTimePickerControl), new PropertyMetadata(TimeSpan.FromHours(12), OnTimeChanged));
    
            public DateTimePickerControl()
            {
                InitializeComponent();
    
                var bdDate = new Binding
                {
                    Mode = BindingMode.TwoWay,
                    Path = new PropertyPath("SelectedDate"),
                    Source = this
                };
    
                var bdTime = new Binding
                {
                    Mode = BindingMode.TwoWay,
                    Path = new PropertyPath("SelectedTime"),
                    Source = this
                };
    
                PART_DatePicker.SetBinding(DatePicker.DateProperty, bdDate);
                PART_TimePicker.SetBinding(TimePicker.TimeProperty, bdTime);
            }
    
            public DateTimeOffset SelectedDate
            {
                get { return (DateTimeOffset) GetValue(SelectedDateProperty); }
                set { SetValue(SelectedDateProperty, value); }
            }
    
            public DateTime SelectedDateTime
            {
                get { return (DateTime) GetValue(SelectedDateTimeProperty); }
                set { SetValue(SelectedDateTimeProperty, value); }
            }
    
            public TimeSpan SelectedTime
            {
                get { return (TimeSpan) GetValue(SelectedTimeProperty); }
                set { SetValue(SelectedTimeProperty, value); }
            }
    
            private static void OnDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = d as DateTimePickerControl;
    
                if (instance == null)
                {
                    return;
                }
    
                var dto = (DateTimeOffset) e.NewValue;
                TimeSpan ts = instance.SelectedTime;
    
                instance.SelectedDateTime = new DateTime(dto.Year, dto.Month, dto.Day, ts.Hours, ts.Minutes, ts.Seconds);
            }
    
            private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = d as DateTimePickerControl;
    
                if (instance == null)
                {
                    return;
                }
    
                DateTimeOffset dto = instance.SelectedDate;
                var ts = (TimeSpan) e.NewValue;
    
                instance.SelectedDateTime = new DateTime(dto.Year, dto.Month, dto.Day, ts.Hours, ts.Minutes, ts.Seconds);
            }
        }
    }

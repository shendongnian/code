    [TemplatePart(Name = "PART_DatePicker", Type = typeof (DatePicker))]
    public class YourCustControl : Control
    {
        public static readonly DependencyProperty SelectedDateChangedCommandProperty = DependencyProperty.Register("SelectedDateChangedCommand", typeof (ICommand), typeof (YourCustControl), new PropertyMetadata(null));
        public static readonly DependencyProperty YourDateTimeProperty = DependencyProperty.Register("YourDateTime", typeof (DateTime), typeof (YourCustControl), new PropertyMetadata(null));
        private DatePicker datePicker;
        static YourCustControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (YourCustControl), new FrameworkPropertyMetadata(typeof (YourCustControl)));
        }
        public ICommand SelectedDateChangedCommand
        {
            get { return (ICommand) GetValue(SelectedDateChangedCommandProperty); }
            set { SetValue(SelectedDateChangedCommandProperty, value); }
        }
        public DateTime YourDateTime
        {
            get { return (DateTime) GetValue(YourDateTimeProperty); }
            set { SetValue(YourDateTimeProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            datePicker = (DatePicker) Template.FindName("PART_DatePicker", this);
            if (datePicker != null)
            {
                datePicker.SelectedDateChanged += datePicker_SelectedDateChanged;
            }
        }
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Execute the command
            if (SelectedDateChangedCommand != null && SelectedDateChangedCommand.CanExecute(e) && !e.Handled)
                SelectedDateChangedCommand.Execute(e);
        }
    }

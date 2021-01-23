    class CustomDatePicker : DatePicker
    {
        private DateTime comparer;
        private Subject<DateTime> dateChangedSubject = new Subject<DateTime>();
        static CustomDatePicker()
        {
            // Override property changed callback for SelectedDate
            DatePicker.SelectedDateProperty.OverrideMetadata(typeof(CustomDatePicker), new FrameworkPropertyMetadata(SelectedDate_PropertyChanged));
        }
        /// <summary>
        /// Subscribe to this observable instead of SelectedDateChanged event
        /// It will only fire once when the selected date changes
        /// </summary>
        public IObservable<DateTime> DateChanged
        {
            get { return this.dateChangedSubject.AsObservable(); }
        }
        /// <summary>
        /// Checks if the comparer is equal to the new value
        /// If it is not, store the new value and fire changed subject
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void SelectedDate_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomDatePicker datePicker = d as CustomDatePicker;
            if(datePicker.comparer != (DateTime)e.NewValue)
            {
                datePicker.comparer = (DateTime)e.NewValue;
                datePicker.dateChangedSubject.OnNext((DateTime)e.NewValue);
            }
        }
    }

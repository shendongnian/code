        private void DateClicked(object sender, SelectionChangedEventArgs e)
        {
            var dt = selectableCalendar.SelectedDate;
            if (_curr == null)
                _curr = selectableCalendar.SelectedDate;
            if (((DateTime)_curr).Month != ((DateTime)dt).Month)
            {
                // blah
            }
        }

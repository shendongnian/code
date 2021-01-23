        private void brewMethodSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            var brewMethodList = sender as ListPicker;
            if (brewMethodList.SelectedItem == manual_list)
            {
                brewMethod = MANUAL;
            }
            else
            {
                brewMethod = AUTO_DRIP;
            }
            update();
        }

        private void DatePicker_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                var btn = datePicker.Template.FindName("PART_Button", this.FollowUpdate) as System.Windows.Controls.Button;
                btn.Focus();
                datePicker.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.First));
                btn.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        private void TileTabControl(object sender, RoutedEventArgs e)
        {
            var Tab = (Button)sender;
            //MessageBox.Show(Type.Tag.ToString());
            switch (Tab.Tag.ToString())
            {
                case "NewShift":
                    break;
                case "RecordedShifts":
                    break;
                case "DetailsOfPay":
                    break;
                case "AccountSettings":
                    break;
                case "ShiftsByMonth":
                    break;
            }
        }

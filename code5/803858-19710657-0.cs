    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var item = comboBox.SelectedItem as EntityType;
                //EntityType == the table you are loading into combobox (I guess it supposed to be UserProfile)
                if (item != null)
                {
                    txtFirst.Text = item.First.ToString();
                    txtSecond.Text = item.Last.ToString();
                }
            }
        }

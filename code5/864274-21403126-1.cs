        private void AddCity(object sender, MouseButtonEventArgs e)
        {
            if (TxtCity.Text != string.Empty)
            {
                Add(TxtCity.Text);
                UpdateData();           ////Here I am updating my listitem
            }
            else
            {
                MessageBox.Show("Add city");
            }
        }

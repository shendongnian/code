    private void ShowState(object sender, GestureEventArgs e)
        {
            var control = sender as Grid;
            if (control != null)
            {
                var entity = (CityListData) control.DataContext;
                MessageBox.Show("You clicked on the state " + entity.city_name);
            }
        }

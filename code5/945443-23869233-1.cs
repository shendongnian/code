    private void DataGrid_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var datag = (DataGrid) sender;
            var p = (Person) datag.SelectedValue;
            var p1 = (Person) e.Row.Item;
            Debug.WriteLine(p.Name + ", " + p.Age);
            Debug.WriteLine(p1.Name + ", "+ p1.Age);
        }

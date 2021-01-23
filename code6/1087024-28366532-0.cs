    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Varname
        {
            ImageWindow imageWindow = new ImageWindow { Owner = this };
            foreach (var item in ListBox.Items) //Varname
            {
                imageWindow.ListBox.Items.Add(item);//Varname
            }
            imageWindow.SetSelectedImageIndex = ListBox.SelectedIndex; //Varname + save the index of the selected item and pass it to ImageWindow
            imageWindow.Show();
        }

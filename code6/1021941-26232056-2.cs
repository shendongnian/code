      private void businessFilterString_TextChanged(object sender, TextChangedEventArgs e)
        {
            sI.ItemsSource = businesses.Collection.Where(b => DeleteAccentAndSpecialsChar(b.name.ToUpper()).Contains(DeleteAccentAndSpecialsChar(searchBox.Text.ToUpper()))).ToList();
            LayoutUpdateFlag = true;
        }

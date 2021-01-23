    private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("MayUserAddRows")) 
        {
            // The MayUserAddRows property is changed
            if (MyViewModel.MayUserAddRows == true) 
            {
                // Allow to add a lot of records
                MyViewModel.CanUserAddRows = true;
            }
            if (MyViewModel.MayUserAddRows == false)
            {
                // Prohibit the addition 
                MyViewModel.CanUserAddRows = false;
 
                // And add the empty row
                AddEmptyRow(MyViewModel.MyCollection);
            }                
        }
    }

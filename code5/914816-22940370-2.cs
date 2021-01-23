    private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("MayUserAddRows"))
        {
            if (MyViewModel.MayUserAddRows == true) 
            {
                MyViewModel.CanUserAddRows = true;
            }
            if (MyViewModel.MayUserAddRows == false)
            {
                MyViewModel.CanUserAddRows = false;
                AddEmptyRow(MyViewModel.MyCollection);
            }                
        }
    }

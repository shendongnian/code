    int i = 0;
    if(!string.IsNullOrEmpty(ChildAge.Text))
    {
        if(!int.TryParse(ChildAge.Text, out i))
            {
                 MessageBox.Show("Enter Valid Age");
            }
    }

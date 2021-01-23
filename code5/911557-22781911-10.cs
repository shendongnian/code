    public MyViewModel() 
    {
        MyModel = new MyModel();        
        MyModel.PropertyChanged += new PropertyChangedEventHandler(MyModel_PropertyChanged);
    }
    private void MyModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("SelectedItem")) 
        {
            System.Diagnostics.Debug.WriteLine("SelectedItem changed");
        }            
    }

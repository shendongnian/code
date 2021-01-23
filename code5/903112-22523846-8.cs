    public MyViewModel() 
    {
        MyModel = new MyModel();        
        MyModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MyModel_PropertyChanged);
    }
    private void MyModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("Text")) 
        {
            System.Diagnostics.Debug.WriteLine("Text changed");
        }            
    }

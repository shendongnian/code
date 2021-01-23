    //Form2
    
    private string value1 = string.Empty;
    public string Value1
    {
       get { return value1; }
       set { value1 = value; }
    }
    
    
    //Form1
    
    private void YourMethod()
    {
        Form2 frm = new Form2();
        frm.Value1 = "This is a sample value to pass in form 2";
        frm.Show();
    
    }

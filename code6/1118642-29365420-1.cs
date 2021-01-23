    public string NameField 
    {
        get
        {
            return txtNameField.Text;
        }
        // maybe you want to make it public
        private set 
        {
            txtNameField.Text = value;
        }
    }

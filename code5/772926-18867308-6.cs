    public bool ShowPassword
    {
        set
        {  
           if (_IsPasswordVisible == value)
                return;
            _IsPasswordVisible = value;
           
           if (_IsPasswordVisible = true)
              textbox1.EditValue = passwordBoxEdit1.Password;
           else
              passwordBox1.Password = textEdit1.Text;
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs("ShowPassword"));
        }

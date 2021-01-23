    public bool TxtBxValidation()
    {
        ...
 
        string strEid = (sender as TextBox).Text;
        if (!Regex.IsMatch(strEid, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$"))
        {
            MessageBox.Show("Please input valid email address ");
            return false;
        }
    }

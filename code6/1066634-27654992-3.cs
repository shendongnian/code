    public bool TxtBxValidation()
    {
        ...
 
        string strEid = <textBox>.Text;
        if (!Regex.IsMatch(strEid, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$"))
        {
            MessageBox.Show("Please input valid email address ");
            return true;
        }
    }

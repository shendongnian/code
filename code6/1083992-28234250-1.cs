    protected void ValidatoreTipiDato_ServerValidate(object source, ServerValidateEventArgs args)
    {
        CustomValidator vc = source as CustomValidator;
        TextBox txt = FindControl(vc.ControlToValidate) as TextBox;
        if (txt != null)
        {
            int x = int.MinValue;
            int.TryParse(txt.Text, out x);
            if (x != int.MinValue)
            {
                // It is a number
            }
            else
            {
                // It is not a nuber
            }
        }
    }

    protected void ValidatoreTipiDato_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int x = int.MinValue;
        int.TryParse(args.Value, out x);
        if (x != int.MinValue)
        {
            // It is a number
        }
        else
        {
            // It is not a nuber
        }
    }

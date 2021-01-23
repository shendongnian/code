    void ServerValidation (object source, ServerValidateEventArgs args)
     {
        if (!string.IsNullOrEmpty(Txt1.Text))
           args.IsValid = !string.IsNullOrEmpty(args.Value);
     }

    protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime minDate = DateTime.Parse("1000/12/28");
        DateTime maxDate = DateTime.Parse("9999/12/28");
        DateTime dt;
    
        args.IsValid = (DateTime.TryParse(args.Value, out dt) 
                        && dt <= maxDate 
                        && dt >= minDate);
    }

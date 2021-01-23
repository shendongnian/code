    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        TestDBDataContext db = new TestDBDataContext();
        args.IsValid = (db.Faculty.Count(x => x.FID == args.Value) == 0);
    }

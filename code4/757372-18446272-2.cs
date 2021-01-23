    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
      if (string.IsNullOrEmpty(args.Value))
      {
        args.IsValid = false;
        ((CustomValidator)source).Text = "Please enter some value.";
      }
      else if (/*Check if has empty space*/)
      {
        args.IsValid = false;
        ((CustomValidator)source).Text = "Spaces are not allowed.";
      }
      else
      {
        args.IsValid = true;
      }
    }

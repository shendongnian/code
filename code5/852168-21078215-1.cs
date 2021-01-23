     public void Process(RenderFieldArgs args)
    {
      Assert.ArgumentNotNull((object) args, "args");
      string fieldTypeKey = args.FieldTypeKey;
      if (fieldTypeKey != "text" && fieldTypeKey != "single-line text")
        return;
      args.WebEditParameters.Add("prevent-line-break", "true");
      args.Result.FirstPart = HttpUtility.HtmlEncode(args.Result.FirstPart);
    }

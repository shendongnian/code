    protected override void Render(HtmlTextWriter writer)
    {
      ClientScript.RegisterForEventValidation(YourButtonThatCausesSubmit.UniqueID.ToString());
      base.Render(writer);
    }

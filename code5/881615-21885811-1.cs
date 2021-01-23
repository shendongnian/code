    protected HtmlControls.HtmlInputHidden hidValue;
    protected void Page_Load(object sender, System.EventArgs e)
    {
       dynamic hiddenValue = hidValue.Value;
       string [] arr=hiddenValue.Split(",");
    }

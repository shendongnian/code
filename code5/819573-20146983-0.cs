    protected override void OnPreInit(EventArgs e)
    {
	base.OnPreInit(e);
	var j = 0;
	foreach (DropDownList control in form1.Controls.OfType<DropDownList>().ToList())
	{
		var div = new HtmlGenericControl();
		div.ID = "div" + j;
		div.TagName = "div";
		div.Attributes["class"] = "myClass";
		div.Controls.Add(control); // or control.Controls.Add(div); but this wouldn't wrap it.
		j++;
		form1.Controls.Add(div);
	}

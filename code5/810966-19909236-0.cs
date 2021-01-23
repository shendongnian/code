    public static IEnumerable<Control> 
        FindControlByAttribute(this Control control, string id)
    {
        var current = control as System.Web.UI.HtmlControls.HtmlControl;
        if (current != null)
        {
            var k = current.Attributes.Keys;
            if (k.Cast<string>().Contains(id))
            {
                yield return current;
            }
        }
        if (control.HasControls())
        {
            foreach (var c in control.Controls.Cast<Control>())
            {
                foreach (var item in c.FindControlByAttribute(id))
                {
                    yield return item;
                }
            }
        }
    }

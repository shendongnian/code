    private IEnumerable<Control> GetEditControls(ControlCollection controls)
    {
        var lst = new List<Control>();
        if (controls == null)
            return lst;
        foreach(var ctrl in controls)
        {
            if (ctrl.Id.EndsWith("EditMode"))
               lst.Add(ctrl);
            lst.AddRange(GetControls(ctrl.Controls);
        }
        return lst;
    }
    // ...
    foreach(RepeaterItem item in repeater1.Items)
    {
         HtmlGenericControl divsEditMode = GetEditControls(item.Controls);
         foreach(var divEditMode in divsEditMode)
         {
              divEditMode.Visible = false;
         }
    }

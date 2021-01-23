    //We just need HtmlInputCheckBox
    IEnumerable<Control> _ctrls = from Control n in this.form1.Controls where n as System.Web.UI.HtmlControls.HtmlInputCheckBox != null select n;
    if (_ctrls.Count() > 0)
    {
        foreach (System.Web.UI.HtmlControls.HtmlInputCheckBox item in _ctrls)
        {
            if (item.Checked)
            {
                //Do something:
                Response.Write(item.Name + " was checked.<br/><br />");
            }
        }
    }

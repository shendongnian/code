    foreach (Control item in this.form1.Controls)
    {
        //We just need HtmlInputCheckBox 
        System.Web.UI.HtmlControls.HtmlInputCheckBox _cbx = item as System.Web.UI.HtmlControls.HtmlInputCheckBox;
        if (_cbx != null)
        {
            if (_cbx.Checked)
            {
                //Do something: 
                Response.Write(_cbx.Name + " was checked.<br />");
            }
        }
    }

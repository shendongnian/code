    var hControl = new HeaderControl();
    var strWriter = new System.IO.StringWriter();
    var htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);
    hControl.Rendercontrol(htmlWriter);
    string ControlAsString = txtWriter.ToString();

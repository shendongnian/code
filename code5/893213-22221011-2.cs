    if (String.IsNullOrWhiteSpace(txt1.Text) || String.IsNullOrWhiteSpace(txt2.Text) || String.IsNullOrWhiteSpace(txt3.Text) || String.IsNullOrWhiteSpace(txt4.Text))
    {
        string message = "Please enter values";
        string script = String.Format("alert('{0}');", message);
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
        return;
    }

    System.Web.UI.HtmlControls.HtmlGenericControl subDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");      
    subDiv.ID = 'DivIndirizzo"+ (i+1)
    subDiv.Class= "col-lg-8";
    subDiv.Controls.Add(
        new TextBox ()
        {
            ID = "txtIndirizzo",
            CssClass= "form-control"
        });
    sbDivIndirizzi.Controls.Add(subDiv);

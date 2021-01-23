     System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
            new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");      
            createDiv.ID = "createDiv";
            createDiv.InnerHtml = " I'm a div, from code behind ";
            this.Controls.Add(createDiv);

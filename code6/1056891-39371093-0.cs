     protected void DDLLanguages_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (Request.RawUrl.Contains("Language") == false )
                {
                    Response.Redirect(Request.RawUrl + "?Language=" + DDLLanguages.SelectedValue);
                }
                else
                {
                 //i need to update the quesry string here 
       Response.Redirect(Request.Url.GetLeftPart(UriPartial.Path)+ "?Language=" + DDLLanguages.SelectedValue);
    
                }
        }

    scDateArticleDate.Field = StartDateFieldName; //always set the field
    
    if(currentItem != null)
    { 
             Sitecore.Web.UI.WebControls.Date scDateArticleDate = e.Item.FindControl("scDateArticleDate") as Sitecore.Web.UI.WebControls.Date;
             if (scDateArticleDate != null)
             {
                    if (DisplayDates)
                    {
                        scDateArticleDate.Item = currentItem;
                        scDateArticleDate.Visible = true;
                    }
                    else
                    {
                        scDateArticleDate.Visible = false;
                    }
             }
    }

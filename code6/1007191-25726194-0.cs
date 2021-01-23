    protected void rptFinalScore_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {             
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var Score = e.Item.FindControl("rpt_Score") as Label;
                var ProgBar = e.Item.FindControl("rpt_proBar") as HtmlGenericControl;
                string BuildingScore = ((Label)Score).Text;
                ProgBar.Attributes.Add("style", string.Format("width:{0}%;", BuildingScore));           
            }
    }

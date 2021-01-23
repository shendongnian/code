    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int ID = int.Parse(((HiddenField)e.Item.FindControl("hfID")).Value);
    
            GridView grd = (GridView)e.Item.FindControl("grd");
            DataContext dc = new DataContext(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
    
            var qry = from p in dc.usp_list_costs(ID)
                        select p;
    
    
            List<usp_list_costsResult> lstCosts = new List<usp_list_costsResult>();
            lstCosts = qry.ToList();
            double dEmpTotal = Convert.ToDouble(lstCosts.Sum(r => r.emp_total));
            double dClientTotal = Convert.ToDouble(lstCosts.Sum(r => r.client_total));
            grd.DataSource = lstCosts;
            grd.DataBind();
    
            grd.FooterRow.Cells[4].Text = "Employee Total:" + dEmpTotal;
            grd.FooterRow.Cells[5].Text = "Client Total:" + dClientTotal;
        }
    }

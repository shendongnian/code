        protected void BannerGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            string direction = ASCENDING;
    
            if (gvSortDirection == SortDirection.Ascending)
            {
                gvSortDirection = SortDirection.Descending;
                direction = DESCENDING;
            }
            else
            {
                gvSortDirection = SortDirection.Ascending;
                direction = ASCENDING;
            }
            try
            {   
                DataTable dt = dtStored;
    
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + direction;
    
                BannerGrid.DataSource = dv;
                BannerGrid.DataBind();     
            }
            catch (Exception ex)
            {
                //Log error
            }
        }

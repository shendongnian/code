    protected void Gridview_Sort(object sender, GridViewSortEventArgs e)
        {
    
           
            WISSModel.WISSEntities context = new WISSModel.WISSEntities();
    
            var sortedGridview = (from r in context.Ranges
                                  where r.isDeleted == false
                                  select new
                                  {
                                      r.RangeId,
                                      r.Description,
                                      r.Country.CountryName,
                                      r.GeographicRegion.RegionName,
                                      r.Base.BaseName,
                                      r.RangeMap.MapName,
                                      r.RangeMap.MapPath,
                                      r.RangeMap.LowLat,
                                      r.RangeMap.LowLong,
                                      r.RangeMap.HighLat,
                                      r.RangeMap.HighLong
                                  }).ToList();
    
            DataTable sortedTable = sortedGridview.CopyToDataTable();
    
            sortedTable.DefaultView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
    
            GridViewRangeSetup.DataSource = sortedTable;
    
            GridViewRangeSetup.DataBind();
    
        }
    
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;
    
            int sort = (int)ViewState["Sort"];
            switch (sort)
            {
                case 0:
                    newSortDirection = "ASC";
                    ViewState["Sort"] = 1;
                    break;
    
                case 1:
                    newSortDirection = "DESC";
                    ViewState["Sort"] = 0;
                    break;
            }
    
            return newSortDirection;
        }

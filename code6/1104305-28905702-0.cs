        protected void RadGridView_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            if (IsPostBack == true)
            {
                foreach (GridColumn thisColumn in e.DetailTableView.Columns)
                {
                    if (thisColumn.CurrentFilterFunction == GridKnownFunction.NoFilter)
                    {
                        thisColumn.CurrentFilterValue = string.Empty;
                    }
                }
            }
        }

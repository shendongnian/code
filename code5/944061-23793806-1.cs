    protected void SectionGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
             //Get the CourseID
            populateSectionGrid();
            DataTable dtSectionGridData = SectionGridView.DataSource as DataTable;
            if(sortExpression == null)
               SectionGridViewSortExpression = e.SortExpression;
            else
               SectionGridViewSortExpression = sortExpression
            if (dtSectionGridData != null)
            {
                DataView dataView = new DataView(dtSectionGridData);
                dataView.Sort = SectionGridViewSortExpression + " " + ConvertSectionSortDirectionToSql(e.SortDirection);
                SectionGridView.DataSource = dataView;
                SectionGridView.DataBind();
            }
        }

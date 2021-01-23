    protected void SectionGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
             //Get the CourseID
            populateSectionGrid();
            DataTable dtSectionGridData = SectionGridView.DataSource as DataTable;

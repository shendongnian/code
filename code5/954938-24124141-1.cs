    private void SortGridView(string sortExpression, string direction)
        {
            DataTable dt = (DataTable)Session["QueryTable"];
            if (direction == ASCENDING)
            {
                suiteReport.DataSource = dt.AsEnumerable().OrderBy(x => x[sortExpression]);
            }
            else
            {
                suiteReport.DataSource = dt.AsEnumerable().OrderByDescending(x => x[sortExpression]);
            }
            suiteReport.DataBind();
        }

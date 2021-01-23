        protected void FlowGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                ddl = e.Row.FindControl("GridDirectionDropDownList") as DropDownList;
                Label direction = (Label)e.Row.FindControl("HiddenDirectionLabel");
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(direction.Text));
            }
        }

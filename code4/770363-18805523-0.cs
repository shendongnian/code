    public class ExtendedGridView : System.Web.UI.WebControls.GridView
    {
        protected override void InitializePager(System.Web.UI.WebControls.GridViewRow row, int columnSpan, System.Web.UI.WebControls.PagedDataSource pagedDataSource)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            
            ul.Attributes.Add("class", "pagination pull-right");
            AddPager(ul, commandArgument: "First", text: "<span class='glyphicon glyphicon-fast-backward'></span>");
            for (int i = 0; i < PageCount; i++)
            {
                AddPager(ul, i);
            }
            AddPager(ul, commandArgument: "Last", text: "<span class='glyphicon glyphicon-fast-forward'></span>");
            row.CssClass = "table-footer";
            row.Cells.Add(new System.Web.UI.WebControls.TableCell());
            row.Cells[0].ColumnSpan = columnSpan;
            row.Cells[0].Controls.AddAt(0, ul);            
        }
        protected virtual void navigate_Click(object sender, EventArgs e)
        {
            string commandArgument = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument.ToString();
            int pageIndex = 0;
            if (!int.TryParse(commandArgument, out pageIndex)) {
                switch (commandArgument)
                {
                    case "First": pageIndex = 0; break;
                    case "Last": pageIndex = PageCount - 1; break;
                    case "Prev": pageIndex = PageIndex - 1; break;
                    case "Next": pageIndex = PageIndex + 1; break;
                }
            }
            OnPageIndexChanging(new System.Web.UI.WebControls.GridViewPageEventArgs(pageIndex));
        }
        private void AddPager(System.Web.UI.Control parentControl, int pageIndex = -1, string commandArgument = null, string text = null)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            if (pageIndex == PageIndex)
                li.Attributes.Add("class", "active");
            System.Web.UI.WebControls.LinkButton button = new System.Web.UI.WebControls.LinkButton();
            button.CommandName = "Page";
            if (text == null)
                button.Text = (pageIndex + 1).ToString();
            else
                button.Text = text;
            if (string.IsNullOrWhiteSpace(commandArgument))
                button.CommandArgument = string.Format("{0}", pageIndex);
            else
                button.CommandArgument = commandArgument;
            button.Click += navigate_Click;
            li.Controls.Add(button);
            parentControl.Controls.Add(li);
        }
    }

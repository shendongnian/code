                //assuming you have a dataset with 1 datatable
                ds.Tables.Add(dt);
                this.GridView1.DataSource=ds;
                DataBind();
                //after binding is complete
                this.headerNames.Text="";
                foreach (var c in GridView1.HeaderRow.Cells)
                {
                    this.headerNames.Text += (((System.Web.UI.WebControls.DataControlFieldCell)(c)).ContainingField).HeaderText+",";
                }

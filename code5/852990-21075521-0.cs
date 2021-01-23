      protected void PurchaseMgmtGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                SetRowData();
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    int rowIndex = Convert.ToInt32(e.RowIndex);
                    if (dt.Rows.Count > 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowIndex]);
                        drCurrentRow = dt.NewRow();
                        ViewState["CurrentTable"] = dt;
                        PurchaseMgmtGridView.DataSource = dt;
                        PurchaseMgmtGridView.DataBind();
    
                        // Delete this
                        //for (int i = 0; i < PurchaseMgmtGridView.Rows.Count - 1; i++)
                        //{
                        //    PurchaseMgmtGridView.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                        //}
                        SetPreviousData();
                    }
                }
            }

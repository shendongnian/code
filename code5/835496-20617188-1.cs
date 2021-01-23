        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateAmount();
        }
        private void ValidateAmount()
        {
            System.Data.DataTable dtGridData = new DataTable();
            DataTable dtCloned = new DataTable();
            dtGridData.Columns.Add("ID", typeof(string));
            dtGridData.Columns.Add("DocumentNumber", typeof(string));
            dtGridData.Columns.Add("NameOfOffsettingAccount", typeof(string));
            dtGridData.Columns.Add("Amount", typeof(string));
            dtGridData.Columns.Add("AssetDescription", typeof(string));
            dtGridData.Columns.Add("Quantity", typeof(string));
            dtGridData.Columns.Add("UnitOfMeasure", typeof(string));
            foreach (GridViewRow row in GridProjectDetails.Rows)
            {
                string Id = ((TextBox)row.FindControl("ID")).Text;
                string DocumentNumber = ((Label)row.FindControl("LabelDocumentNumber")).Text;
                string NameOfOffsettingAccount = ((Label)row.FindControl("TextName")).Text;
                string Amount = ((TextBox)row.FindControl("TextAmount")).Text;
                string AssetDescription = ((TextBox)row.FindControl("TextAssetDescription")).Text;
                string Quantity = ((TextBox)row.FindControl("TextQuantity")).Text;
                string UnitOfMeasure = ((DropDownList)row.FindControl("DropDownUnitOfMeasure")).Text;
               
                DataRow dr = dtGridData.NewRow();
                dr["Id"] = Id;
               
                dr["DocumentNumber"] = DocumentNumber;
                dr["NameOfOffsettingAccount"] = NameOfOffsettingAccount;
                if (Amount.Contains(','))
                {
                    Amount = Amount.Replace(",", "");
                }
                dr["Amount"] = Amount;
                dr["AssetDescription"] = AssetDescription;
                dr["Quantity"] = Quantity;
                dr["UnitOfMeasure"] = UnitOfMeasure;                
                dtGridData.Rows.Add(dr);
                dtCloned = dtGridData.Clone();
                dtCloned.Columns["Amount"].DataType = typeof(double);
                foreach (DataRow arow in dtGridData.Rows)
                {
                    dtCloned.ImportRow(arow);
                }
            }
            var result = (from f in dtCloned.AsEnumerable()
                          group f by f.Field<string>("AssetDescription") into g
                          select
                          new
                          {
                              AssetDescription = g.Key,
                              TotalAmount = g.Sum(r => r.Field<double?>("Amount"))
                          });
            foreach (var aAsset in result.AsEnumerable())
            {
                if (aAsset.TotalAmount < 0)
                {
                    if (!lblMessage.Text.Contains("<br/> Total Amount cannot be negative for same asset - "
                                                  + aAsset.AssetDescription.ToString()))
                    {
                        lblMessage.Text = lblMessage.Text + "\n" + "<br/> Total Amount cannot be negative for same asset - " + aAsset.AssetDescription.ToString();
                        lblMessage.Attributes.Add("style", "color:Red;font-weight:bold;");
                        lblMessage.Visible = true;
                    }
                    foreach (GridViewRow arow in GridProjectDetails.Rows)
                    {
                        string AssetDescription = ((TextBox)arow.FindControl("TextAssetDescription")).Text;
                        if (AssetDescription == aAsset.AssetDescription)
                        {
                            ((TextBox)arow.FindControl("TextAmount")).CssClass =
                                ((TextBox)arow.FindControl("TextAmount")).CssClass.Replace("amount", " ");
                            ((TextBox)arow.FindControl("TextAmount")).CssClass = "erroramount";
                        }
                    }
                }
            }
        }

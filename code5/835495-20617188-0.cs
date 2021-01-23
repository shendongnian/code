        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateAmount();
        }
        private void ValidateAmount()
        {
            System.Data.DataTable dtGridData = new DataTable();
            DataTable dtCloned = new DataTable();
            dtGridData.Columns.Add("ID", typeof(string));
            dtGridData.Columns.Add("CapitalizationProjectID", typeof(string));
            dtGridData.Columns.Add("CapitalizationFormID", typeof(string));
            dtGridData.Columns.Add("DocumentNumber", typeof(string));
            dtGridData.Columns.Add("RowPosition", typeof(string));
            dtGridData.Columns.Add("WBSElement", typeof(string));
            dtGridData.Columns.Add("PODocument", typeof(string));
            dtGridData.Columns.Add("PODocumentText", typeof(string));
            dtGridData.Columns.Add("NameOfOffsettingAccount", typeof(string));
            dtGridData.Columns.Add("Amount", typeof(string));
            dtGridData.Columns.Add("PostingDate", typeof(string));
            dtGridData.Columns.Add("CostAllocation", typeof(string));
            dtGridData.Columns.Add("PlantCode", typeof(string));
            dtGridData.Columns.Add("LocationCode", typeof(string));
            dtGridData.Columns.Add("Location", typeof(string));
            dtGridData.Columns.Add("CostCenter", typeof(string));
            dtGridData.Columns.Add("CostCenterDescription", typeof(string));
            dtGridData.Columns.Add("AssetDescription", typeof(string));
            dtGridData.Columns.Add("DateAssetPutIntoService", typeof(string));
            dtGridData.Columns.Add("TagNumber", typeof(string));
            dtGridData.Columns.Add("Quantity", typeof(string));
            dtGridData.Columns.Add("UnitOfMeasure", typeof(string));
            dtGridData.Columns.Add("IsAdditionToExistingAsset", typeof(string));
            dtGridData.Columns.Add("IsSubAsset", typeof(string));
            dtGridData.Columns.Add("Serial", typeof(string));
            dtGridData.Columns.Add("Vendor", typeof(string));
            dtGridData.Columns.Add("Manufacturer", typeof(string));
            dtGridData.Columns.Add("IsDeleted", typeof(string));
            dtGridData.Columns.Add("IsSplit", typeof(string));
            dtGridData.Columns.Add("SplitReference", typeof(string));
            dtGridData.Columns.Add("NoOfSplits", typeof(string));
            foreach (GridViewRow row in GridProjectDetails.Rows)
            {
                string Id = ((TextBox)row.FindControl("ID")).Text;
                string CapitalizationProjectID = ((TextBox)row.FindControl("CapitalizationProjectID")).Text;
                string CapitalizationFormID = ((TextBox)row.FindControl("CapitalizationFormID")).Text;
                string DocumentNumber = ((Label)row.FindControl("LabelDocumentNumber")).Text;
                string RowPosition = ((Label)row.FindControl("LabelRowPosition")).Text;
                string WBSElement = ((Label)row.FindControl("TextWBSElement")).Text;
                string PODocument = ((Label)row.FindControl("TextPurchDoc")).Text;
                string PODocumentText = ((Label)row.FindControl("TextPurchaseOrderText")).Text;
                string NameOfOffsettingAccount = ((Label)row.FindControl("TextName")).Text;
                string Amount = ((TextBox)row.FindControl("TextAmount")).Text;
                string PostingDate = ((Label)row.FindControl("TextPostingDate")).Text;
                string CostAllocation = ((TextBox)row.FindControl("TextCostAllocation")).Text;
                string PlantCode = ((TextBox)row.FindControl("TextPlantCode")).Text;
                string LocationCode = ((TextBox)row.FindControl("TextLocationCode")).Text;
                string Location = ((TextBox)row.FindControl("TextLocation")).Text;
                string CostCenter = ((TextBox)row.FindControl("TextCostCenter")).Text;
                string CostCenterDescription = ((TextBox)row.FindControl("TextCostCenterDescription")).Text;
                string AssetDescription = ((TextBox)row.FindControl("TextAssetDescription")).Text;
                string DateAssetPutIntoService = ((TextBox)row.FindControl("TextDateAssetPutIntoService")).Text;
                string TagNumber = ((TextBox)row.FindControl("TextTagNumber")).Text;
                string Quantity = ((TextBox)row.FindControl("TextQuantity")).Text;
                string UnitOfMeasure = ((DropDownList)row.FindControl("DropDownUnitOfMeasure")).Text;
                string IsAdditionToExistingAsset = ((TextBox)row.FindControl("TextIsAdditionToExistingAsset")).Text;
                string IsSubAsset = ((TextBox)row.FindControl("TextIsSubAsset")).Text;
                string Serial = ((TextBox)row.FindControl("TextSerial")).Text;
                string Vendor = ((TextBox)row.FindControl("TextVendor")).Text;
                string Manufacturer = ((TextBox)row.FindControl("TextManufacturer")).Text;
                string IsSplit = ((TextBox)row.FindControl("IsSplit")).Text;
                string SplitReference = ((TextBox)row.FindControl("SplitReference")).Text;
                string NoOfSplits = ((TextBox)row.FindControl("NoOfSplits")).Text;
                DataRow dr = dtGridData.NewRow();
                dr["Id"] = Id;
                dr["CapitalizationProjectID"] = CapitalizationProjectID;
                dr["CapitalizationFormID"] = CapitalizationProjectID;
                dr["DocumentNumber"] = DocumentNumber;
                dr["RowPosition"] = RowPosition;
                dr["WBSElement"] = WBSElement;
                if (PODocument != "")
                {
                    dr["PODocument"] = PODocument;
                }
                else
                {
                    dr["PODocument"] = null;
                }
                dr["PODocumentText"] = PODocumentText;
                dr["NameOfOffsettingAccount"] = NameOfOffsettingAccount;
                if (Amount.Contains(','))
                {
                    Amount = Amount.Replace(",", "");
                }
                dr["Amount"] = Amount;
                dr["PostingDate"] = PostingDate;
                dr["CostAllocation"] = CostAllocation;
                dr["PlantCode"] = PlantCode;
                dr["LocationCode"] = LocationCode;
                dr["Location"] = Location;
                dr["CostCenter"] = CostCenter;
                dr["CostCenterDescription"] = CostCenterDescription;
                dr["AssetDescription"] = AssetDescription;
                dr["DateAssetPutIntoService"] = DateAssetPutIntoService;
                dr["TagNumber"] = TagNumber;
                dr["Quantity"] = Quantity;
                dr["UnitOfMeasure"] = UnitOfMeasure;
                dr["IsAdditionToExistingAsset"] = IsAdditionToExistingAsset;
                dr["IsSubAsset"] = IsSubAsset;
                dr["Serial"] = Serial;
                dr["Vendor"] = Vendor;
                dr["Manufacturer"] = Manufacturer;
                dr["IsSplit"] = IsSplit;
                dr["SplitReference"] = SplitReference;
                dr["NoOfSplits"] = NoOfSplits;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["CurrentData"] == null) return;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentData"];
        if (dtCurrentTable.Rows.Count == 0) return;
        int rowIndex = 0;
        var dtDealerCode = txtIDealerCode.Text;
        var dtInvoiceNo = txtInvoiceNumber.Text;
        var dtInvoiceDate = DateTime.Parse(txtInvoiceDate.Text);
        var dtDiscountRate = decimal.Parse(txtDiscount.Text);
        var dtDiscount = decimal.Parse(txtProductDiscount.Text);
        var dtIssueMode = ddlIssueMode.SelectedValue;
        var dtUploadedStatus = DateTime.Parse(txtInvoiceDate.Text);
        var dtInsertedDate = "1"; //Really? 
        var dtUploadedDate = DateTime.Parse(txtInvoiceDate.Text);
        var dtForce = txtForce.Text;
        var dtPrinciple = decimal.Parse(txtPrinciple.Text);
        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        {
            var dtItemIdentityCode = (Label)GridView1.Rows[rowIndex].Cells[1].FindControl("ItemCode");
            var dtPurchasingPrice = decimal.Parse((Label)GridView1.Rows[rowIndex].Cells[3].FindControl("UnitPrice"));
            var dtQty = decimal.Parse((Label)GridView1.Rows[rowIndex].Cells[6].FindControl("Quantity"));
            var dtTotal = decimal.Parse((Label)GridView1.FooterRow.FindControl("GetTotal"));
            var dtExpireDate = DateTime.Parse((Label)GridView1.Rows[rowIndex].Cells[5].FindControl("ExpiaryDate"));
            var dtBatchNumber = (Label)GridView1.Rows[rowIndex].Cells[4].FindControl("Batch");
            var NewTotal = decimal.Parse((Label)GridView1.FooterRow.FindControl("GetQuantity"));
            
            InsertRec(dtDealerCode,dtInvoiceNo,dtInvoiceDate,dtItemIdentityCode,
                dtPurchasingPrice,dtDiscountRate,dtDiscount,dtIssueMode,dtQty,
                dtTotal,dtExpireDate,dtBatchNumber,dtUploadedStatus,dtInsertedDate,
                dtUploadedDate,dtForce,dtPrinciple,NewTotal);
            rowIndex++;
        }
    }

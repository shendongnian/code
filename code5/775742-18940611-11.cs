    private void InsertRec(string DealerCode,string InvoiceNo,DateTime InvoiceDate,
                string ItemIdentityCode,decimal PurchasingPrice, decimal DiscountRate,
                decimal Discount,string IssueMode,decimal Qty,decimal Total,
                DateTime ExpireDate,string BatchNumber,string UploadedStatus,
                string InsertedDate,DateTime UploadedDate,string Force,
                decimal Principle,decimal NewTotal)
    {
        const string sqlStatement =
                "INSERT INTO DEL_PurchasesLines1 (" +
                  "DealerCode,InvoiceNo,InvoiceDate,ItemIdentityCode,PurchasingPrice,DiscountRate,Discount,IssueMode,Qty,Total,ExpireDate,BatchNumber,UploadedStatus,InsertedDate,UploadedDate,Force,Principle,NewTotal" + 
                ") VALUES (" +
                  "@DealerCode, @InvoiceNo, @InvoiceDate, @ItemIdentityCode, @PurchasingPrice, @DiscountRate, @Discount, @IssueMode, @Qty, @Total, @ExpireDate, @BatchNumber, @UploadSTatus, @InsertedDate, @UploadedDate, @Force, @Principle, @NewTotal" +
                ")";
        using (conn = new SqlConnection(GetConnectionString())
        using (cmd = new SqlCommand(sqlStatement, conn))
        {
            cmd.Parameters.Add("@DealerCode", SqlDbType.NVarChar, 10).Value = DealerCode;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 10).Value = InvoiceNo;
            cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = InvoiceDate;
            cmd.Parameters.Add("@ItemIdentityCode", SqlDbType.NVarChar, 10).Value = ItemIdentityCode;
            cmd.Parameters.Add("@PurchasingPrice", SqlDbType.Decimal).Value = PurchasingPrice;
            cmd.Parameters.Add("@DiscountRate", SqlDbType.Decimal).Value = DiscountRate;
            //...
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
    }

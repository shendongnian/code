    private void InsertRec(DEL_PurchasesLines1[] linesToInsert)
    {
        const string sqlBase =
                "INSERT INTO DEL_PurchasesLines1 (" +
                  "(DealerCode,InvoiceNo,InvoiceDate,ItemIdentityCode,PurchasingPrice,DiscountRate,Discount,IssueMode,Qty,Total,ExpireDate,BatchNumber,UploadedStatus,InsertedDate,UploadedDate,Force,Principle,NewTotal)" + 
                " VALUES ";
        const string valueBase = 
                  "{0}(@DealerCode{1}, @InvoiceNo{1}, @InvoiceDate{1}, @ItemIdentityCode{1}, @PurchasingPrice{1}, @DiscountRate{1}, @Discount{1}, @IssueMode{1}, @Qty{1}, @Total{1}, @ExpireDate{1}, @BatchNumber{1}, @UploadSTatus{1}, @InsertedDate{1}, @UploadedDate{1}, @Force{1}, @Principle{1}, @NewTotal{1})";
        var sb = new StringBuilder(sqlBase);
        if (DEL_PurchasesLines1.Length > 1) sb.Append("(")
        var delimiter = "";
        for (int i = 0;i<DEL_PurchasesLines1.Length;i++)
        {
             sb.AppendFormat(valueBase, i, delimiter);
             delimiter = ",";
        }
        if (DEL_PurchasesLines1.Length > 1) sb.Append(")")
        using (conn = new SqlConnection(GetConnectionString())
        using (cmd = new SqlCommand(sqlStatement, conn))
        {
            for (int i = 0;i<DEL_PurchasesLines1.Length;i++)
            {
                cmd.Parameters.Add("@DealerCode" + i, SqlDbType.NVarChar, 10).Value = linesToInsert[i].DealerCode;
                cmd.Parameters.Add("@InvoiceNo" + i, SqlDbType.NVarChar, 10).Value = linesToInsert[i].InvoiceNo;
                cmd.Parameters.Add("@InvoiceDate + i", SqlDbType.DateTime).Value = linesToInsert[i].InvoiceDate;
                cmd.Parameters.Add("@ItemIdentityCode" + i, SqlDbType.NVarChar, 10).Value = linesToInsert[i].ItemIdentityCode;
                cmd.Parameters.Add("@PurchasingPrice" + i, SqlDbType.Decimal).Value = linesToInsert[i].PurchasingPrice;
                cmd.Parameters.Add("@DiscountRate" + i, SqlDbType.Decimal).Value = linesToInsert[i].DiscountRate;
            //...
            }
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

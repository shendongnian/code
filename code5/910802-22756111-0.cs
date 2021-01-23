    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
    {
         DataRow data = result.Tables[0].Rows[i];
         var periodStartDate = Convert.ToDateTime(data.Table.Rows[i]["Date"].ToString().Remove(10));
         var periodEndDate = Convert.ToDateTime(data.Table.Rows[i]["Date"].ToString().Remove(0, 12));
         calc.PeriodStartDate = periodStartDate;
         calc.PeriodEndDate = periodEndDate;
         calc.InvoiceAmount = Convert.ToDecimal(data.Table.Rows[i]["Invoice amount"].ToString());
         calc.InterestRate = Convert.ToDecimal(data.Table.Rows[i]["Interest rate"].ToString());
         calc.InterestAmount = Convert.ToDecimal(data.Table.Rows[i]["Interest amount"].ToString());
         calc.Amortization = Convert.ToDecimal(data.Table.Rows[i]["Amortization"].ToString());
         calc.PresentValue = Convert.ToDecimal(data.Table.Rows[i]["Capital balance"].ToString());
         calc.StartValue = Convert.ToDecimal(data.Table.Rows[0]["Capital balance"].ToString());
         cList.Add(calc);
    }

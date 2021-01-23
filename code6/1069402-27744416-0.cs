      string incomeQry = "SELECT SUM([Total income]) FROM [Income] WHERE [Month] = 'Januari';";
      decimal totalIncome = 0m;
      try
      {
        using (OleDbConnection cnxn = new OleDbConnection("connection string..."))
        {
          using (OleDbCommand cmd = new OleDbCommand(incomeQry, cnxn))
          {
            cmd.CommandType = System.Data.CommandType.Text;
            totalIncome = (Decimal)cmd.ExecuteScalar();
            total_income.Text = totalIncome.ToString();
          }
        }
      }
      catch (Exception)
      {        
        throw;
      }

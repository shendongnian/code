    DataSet dsQuote = new DataSet("dsQuote");
    DataTable dtQuoteHed = new DataTable("dtQuoteHed");
    dtQuoteHed.Columns.Add("QuoteNum", typeof(int));
    dtQuoteHed.Columns.Add("TerritoryTerritoryDesc", typeof(string));
    dtQuoteHed.Columns.Add("DueDate", typeof(DateTime));
    dtQuoteHed.Columns.Add("BTCustID", typeof(string));
    dtQuoteHed.Columns.Add("CustomerName", typeof(string));      
    dtQuoteHed.Columns.Add("QuoteAmt", typeof(decimal));
    dtQuoteHed.PrimaryKey = new DataColumn[] { dtQuoteHed.Columns["QuoteNum"] };

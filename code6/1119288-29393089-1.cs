    private void SetSessionGlobalization(Oracle.DataAccess.Client.OracleConnection aConnection)
    {
    
         OracleGlobalization info = aConnection.GetSessionInfo();
         System.Globalization.CultureInfo lCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
         var ri = new System.Globalization.RegionInfo(lCultureInfo.LCID);
    
         info.Calendar = lCultureInfo.Calendar.GetType().Name.Replace("Calendar", String.Empty);         
         info.Currency = ri.CurrencySymbol;
         info.DualCurrency = ri.CurrencySymbol;
         info.ISOCurrency = ri.ISOCurrencySymbol;
         info.DateFormat = lCultureInfo.DateTimeFormat.ShortDatePattern + " " + lCultureInfo.DateTimeFormat.ShortTimePattern.Replace("HH", "HH24").Replace("mm", "mi");
         info.DateLanguage = System.Text.RegularExpressions.Regex.Replace(lCultureInfo.EnglishName , @" \(.+\)",String.Empty);
         info.NumericCharacters = lCultureInfo.NumberFormat.NumberDecimalSeparator + lCultureInfo.NumberFormat.NumberGroupSeparator;
         info.TimeZone = String.Format("{0}:{1}", TimeZoneInfo.Local.BaseUtcOffset.Hours,  TimeZoneInfo.Local.BaseUtcOffset.Minutes);
         info.Language = ...
         info.Territory = ...
         info.TimeStampFormat = ...
         info.TimeStampTZFormat = ...
    
         try {
            aConnection.SetSessionInfo(info);
         } catch ( OracleException err ) {
            MessageBox.Show(err.Message);
         }
    }

    @{
       DateTime date;
       
       if (DateTime.TryParseExact(item.ItemArray[0],
                                   "yyyyMMdd", 
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None, 
                                   out date))
        {
          <span class="visitDate">date.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture))</span>            //valid
        }
    }

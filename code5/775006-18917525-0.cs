    var dateString = "20130912"; //rows[row][4].ToString()
    DateTime parsedDateTime;
    var DateTimeParseFail= DateTime.TryParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime);
    
    if (!DateTimeParseFail) {
       msg = "Data Feed Convert string to DateTime: Date " + rows[row][4].ToString() + " - " + value.ToString();
       ComponentMetaData.FireError(0, ComponentMetaData.Name, msg, string.Empty, 0, out pbCancel);
       throw new Exception(msg);
    }  else {
       buffer[colIndex] = parsedDateTime;
    }

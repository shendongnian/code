    DateTime startT = new DateTime();
    DateTime endT = new DateTime();
    startT = dateTimePickerSearch.Value.Date; // Ex: 2014-11-24 12:00:00
    endT = dateTimePickerSearch.Value.Date.AddDays(1).AddSeconds(-1); // Ex: 2014-11-24 11:59:59
    "Select * From tbl_Perdoruesi WHERE DATA Between '" + startT + "' AND '" + endT + "'"

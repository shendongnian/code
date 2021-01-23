    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
    settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    List<GraphDataItem<DateTime, int>> items = GetItems();
    var json = JsonConvert.SerializeObject(items, settings);

    dynamic collection = serviceResponse.GetType().GetProperty("SummaryList").GetValue(serviceResponse, null);
    foreach (var item in collection)
    {
        var value = item.Name;
    }

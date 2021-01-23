    dataHistory.Add(dataTlt);
    // remove first result if history has over 10 elements
    if(dataHistory.Count > 10)
      dataHistory.RemoveAt(0);
    // now, update your label
    collectedLbl.Content = String.Join("\n", dataHistory);

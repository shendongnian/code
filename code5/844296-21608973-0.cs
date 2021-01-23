    private static Dictionary<String, CellEntry> GetCellEntryMap(
        SpreadsheetsService service, CellFeed cellFeed, List<CellAddress> cellAddrs)
    {
      CellFeed batchRequest = new CellFeed(new Uri(cellFeed.Self), service);
      foreach (CellAddress cellId in cellAddrs)
      {
        CellEntry batchEntry = new CellEntry(cellId.Row, cellId.Col, cellId.IdString);
        batchEntry.Id = new AtomId(string.Format("{0}/{1}", cellFeed.Self, cellId.IdString));
        batchEntry.BatchData = new GDataBatchEntryData(cellId.IdString, GDataBatchOperationType.query);
        batchRequest.Entries.Add(batchEntry);
      }
      CellFeed queryBatchResponse = (CellFeed)service.Batch(batchRequest, new Uri(cellFeed.Batch));
      Dictionary<String, CellEntry> cellEntryMap = new Dictionary<String, CellEntry>();
      foreach (CellEntry entry in queryBatchResponse.Entries)
      {
        cellEntryMap.Add(entry.BatchData.Id, entry);
        Console.WriteLine("batch {0} (CellEntry: id={1} editLink={2} inputValue={3})",
            entry.BatchData.Id, entry.Id, entry.EditUri,
            entry.InputValue);
      }
      return cellEntryMap;
    }

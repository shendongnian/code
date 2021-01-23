    private class Row
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string Info { get; set; }
    }
...
    var mappings = new Action<string, Row>[]
    {
        (value, row) => row.Name = value,
        (value, row) => row.Number = int.Parse(value),
        (value, row) => row.State = value,
        (value, row) => row.Info = value
    };
    var doc = ... // Load the document
    var trs = doc.DocumentNode.Descendants("TR"); // Give you all the TRs
    foreach (var tr in trs)
    {
      var row = new Row();
      tr.Descendants("TD").Zip(mappings, (td, map) =>
      {
          map(td.InnerText, row);
          return true;
      });
      // You now have a populated row.
    }

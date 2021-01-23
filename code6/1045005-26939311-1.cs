    public class Cell
    {
      public string Text { get; set; }
      public int ID { get; set; }
      public CellStyle Style { get; set; }
    }
    
    public class CellStyle
    {
      public string BgColor { get; set; }
      public string TextColor { get; set; }
    }
    string json = @"{
      'Text': 'My Cell',
      'ID': 20,
      'TsID': 100,
      'Style':  {
                  'BgColor' : 'Red',
                  'TextColor' : 'Black',
                  'Caption' : 'Help My Cell',
                }
    }";
    
    var orgCell = JsonConvert.DeserializeObject<Cell>(json);
    orgCell.Style.TextColor = "White";
    orgCell.Style.BgColor = "Blue";
    
    var obj = JsonConvert.SerializeObject(orgCell);
    JObject o1 = JObject.Parse(json);
    JObject o2 = JObject.Parse(obj);
    o1.Merge(o2, new JsonMergeSettings
    {
      // union array values together to avoid duplicates
      MergeArrayHandling = MergeArrayHandling.Union
    });
    
    o1.ToString(); // gives me the intended string 

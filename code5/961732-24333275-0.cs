    public class MyEntity : TableEntity
    {
      public MyEntity(string imageId, string featureId)
      {
        this.PartitionKey = imageId;
        this.RowKey = featureId;
      }
    
      public string Container { get; set; }
      public bool FeatureEnabled { get; set; }
      public int data { get; set; }
      public PointF Point;
      public double X { get; set; }
      public double Y { get; set; }
    
    }

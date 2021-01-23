    [DataContract]
    public class Point { 
      [DataMember]
      public int X { get; set; }
      [DataMember]
      public int Y { get; set; }
    }
    litServerModel.Text = serializer.SerializeString<Point>(new Point { 
      X = 1, 
      Y = 2 
    });

    class JSONThing {
      public JSONThingData[] { get; set; }
    }
    class JSONThingData {
      public string ID { get; set; }
      public string name { get; set; }
      public string objcode { get; set; }
      public JSONThingDataOwner owner { get; set;}
    }
    ...

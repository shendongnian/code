    class TradingStrategy
    {
      public string Name { get; set; }
    }
    class MATest : TradingStrategy
    {
      // this is not needed if it is inherited by TradingStragegy
      // You should be getting a warning that you are hiding
      // the field/property
      // public string Name { get; set; }
      // Should probably be more descriptive
      // e.g. LengthInFeet...
      public int Length { get; set; }
      public float Lots { get; set; }
      // I recommended boolean properties to be prefixed with
      // Is, Can, Has, etc
      public bool CanTrendFollow { get; set; }
    }
    // Somewhere Else...
    var MATests = new List<MATest>()
    {
      new MATest()
      {
        Name = "MATest",
        Length = 12,
        Lots = 0.1F,
        CanTrendFollow = true
      },
      new MATest()
      {
        Name = "MATest",
        Length = 24,
        Lots = 0.1F,
        CanTrendFollow = true
      },
    }

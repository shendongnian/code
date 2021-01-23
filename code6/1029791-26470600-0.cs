    class GrowCounts {
      public Int32 TopCount { get; set; }
      public Int32 RightCount { get; set; }
      public Int32 BottomCount { get; set; }
      public Int32 LeftCount { get; set; }
      public GrowDirections MaxGrowDirection {
        get { // Return GrowDirections.Top if TopCount has the highest count etc. }
      }
    }

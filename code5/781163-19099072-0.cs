    public class ControlAndTopLevelControlPair : IEqualityComparer<ControlAndTopLevelControlPair>
    {
      public int CONTROLOI { get; set; }
      public int VIEWCONTROL_OI { get; set; }
      public override int GetHashCode() {  return CONTROLOI ^ VIEWCONTROL_OI; }
      public override bool Equals (object other) 
      {
         // your implementation
      }
    }

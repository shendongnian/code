    public class ControlAndTopLevelControlPair {
      public int CONTROLOI { get; set; }
      public int VIEWCONTROL_OI { get; set; }
      public override bool Equals(object x)
      {
         ControlAndTopLevelControlPair c = x as ControlAndTopLevelControlPair;
         if(c == null) return false;
         return c.CONTROLOI.Equals(CONTROLOI) && c.VIEWCONTROL_OI.Equals(VIEWCONTROL_OI);
      }
      public override int GetHashCode()
      {
         return CONTROLOI.GetHashCode( ) ^ VIEWCONTROL_OI.GetHashCode( );
      }
    }

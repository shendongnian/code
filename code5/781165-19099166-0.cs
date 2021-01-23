    public class ControlAndTopLevelControlPair : IEquatable<ControlAndTopLevelControlPair>
    {
        public int CONTROLOI { get; set; }
        public int VIEWCONTROL_OI { get; set; }
        public bool Equals(ControlAndTopLevelControlPair other)
        {
            if (other == null) return false;
            return CONTROLOI.Equals(other.CONTROLOI)
                && VIEWCONTROL_OI.Equals(other.VIEWCONTROL_OI);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ControlAndTopLevelControlPair);
        }
        public override int GetHashCode()
        {
            return CONTROLOI.GetHashCode() ^ VIEWCONTROL_OI.GetHashCode();
        }
    }

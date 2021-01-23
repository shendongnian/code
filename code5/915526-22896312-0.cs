    public class Beam : IComparable
    {
        public double Elevation; //consider changing this to property, btw.
        public int CompareTo(object obj) {
             if (obj == null) return 1;
             Beam otherBeam = obj as Beam;
             return this.Elevation.CompareTo(otherBeam.Elevation);
        }
    }

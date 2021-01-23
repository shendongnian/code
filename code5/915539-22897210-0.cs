using System.Linq;
	public class Beam
	{
			public double Elevation;
			protected bool Equals(Beam other)
			{
				return Elevation.Equals(other.Elevation);
			}
			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((Beam) obj);
			}
			public override int GetHashCode()
			{
				return Elevation.GetHashCode();
			}
	}
var distinctBeams = beams.Distinct()

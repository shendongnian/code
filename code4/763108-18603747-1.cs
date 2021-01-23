	public class Solution : IComparable<Solution>
	{ 
		public readonly int MaxLengths = 4; 
		public readonly decimal Value; 
		public readonly decimal MaxValue = 120.00m; 
		public readonly bool IsValid;
		public readonly decimal[] Lengths; 
		public Solution(decimal[] lengths)
		{ 
			this.Lengths = lengths; 
			if (lengths.Length > 4)
				throw new ArgumentException("Too many lengths."); 
			foreach (var dec in lengths) {
				if (dec <= 0.00m)
					throw new ArgumentException(); 
				Value += dec; 
			}
			IsValid = Value < 120.00m; 
		}		
		public int CompareTo(Solution other)
		{
			if (this.Value > other.Value) return 1; 
			else if (this.Value == other.Value) return 0; 
			else return -1; 
		}
 		public override string ToString()
		{
			var value = string.Format("[Solution] Lengths:");
			foreach (var d in Lengths) { 
				value += d + ", "; 
			}
			value += this.Value; 
			return value.ToString(); 
		}
	}

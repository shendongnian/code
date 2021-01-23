	public class A
	{
		public int Id { get; set; }
		public int PAsInt { get; set; }
		[NotMapped]
		public E P {
			get { return (E) PAsInt; }
			set { PAsInt = (int) value; }
		}
		public enum E { }
	}

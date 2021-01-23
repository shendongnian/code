	public partial class Grid_Dienste : UserControl {
	
	    public static Grid_Dienste	 current	 { get; set; }
		public Grid_Dienste()
		{
			current = this;
			...
			
		// this is the prerequsite, works on singeltons

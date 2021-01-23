		protected void Page_Load(object sender, EventArgs e)
			{
			System.Diagnostics.Debug.WriteLine("Selected index in Page_Load: "+LB1.SelectedIndex);
			}
		protected void LB1_SelectedIndexChanged(object sender, EventArgs e)
			{
			System.Diagnostics.Debug.WriteLine("Selected index in LB1_SelectedIndexChanged: "+LB1.SelectedIndex);
			}
		

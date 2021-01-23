    public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}
		private void UserControl1_Load(object sender, EventArgs e)
		{
			if (DesignMode)
			{
				return;
			}
			AssignFont();
		}
		#region Overrides of Control
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				var g = e.Graphics;
				g.FillRectangle(Brushes.White, e.ClipRectangle);
				g.DrawString("Hi there", MyFont, Brushes.Black, 0, 0); // <--- this will fail
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.Message);
			}
		}
		#endregion
		void AssignFont()
		{
			using (Font f = new Font("Shyam", 2))
			{
				this.MyFont = f;
			} // <---- MyFont now points to a disposed object
		}
		public Font MyFont { get; set; }
	}

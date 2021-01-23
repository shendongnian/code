    public partial class DataGridViewExt : DataGridView
	{
		public DataGridViewExt()
		{
			InitializeComponent();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				base.OnPaint(e);
			}
			catch (Exception)
			{
				this.Invalidate();
			}
		}
	}

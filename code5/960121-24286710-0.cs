    public partial class MyDataGridView : DataGridView
    {
		public StatusStrip Footer
		{
			get { return (StatusStrip)this.Controls["Footer"]; }
		}
		private bool _footerVisible;
		[Browsable(false)]
		///
		/// Sets or Gets the value specifying if a footer bar is shown or not
		///
		public bool FooterVisible
		{
			get { return _footerVisible; }
			set
			{
				_footerVisible = value;
				this.Controls["Footer"].Visible = _footerVisible;
			}
		}
		public MyDataGridView()
		{
			InitializeComponent();
			StatusStrip footer = new StatusStrip();
			footer.Name = "Footer";
			footer.ForeColor = Color.Black;
			this.Controls.Add(footer);
			((StatusStrip)this.Controls["Footer"]).Visible = _footerVisible;
			((StatusStrip)this.Controls["Footer"]).VisibleChanged += new EventHandler(RDataGridView_VisibleChanged);
			this.Scroll += new ScrollEventHandler(RDataGridView_Scroll);
			_footerItems = ((StatusStrip)this.Controls["Footer"]).Items;
		}
	}

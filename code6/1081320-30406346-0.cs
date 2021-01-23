	public partial class CJL_DropPanelCtrl : UserControl
	{
		internal bool IsDropped { get; set; }		// true if the panel is visible
		
		internal Panel DropPanel { get; private set; }	// the panel make the public set to set your own panel as needed
		/// <summary>
		/// The Control where the DropPanel will be in the Z-order chain
		/// </summary>
		internal Control PanelParent
		{ get {	return DropPanel.Parent; }
		  set 
			{	
			  DropPanel.Parent = value;
			  SetLocation();
			}
		}
		public CJL_DropPanelCtrl()
		{
			InitializeComponent();
			IsDropped = false;
			DropPanel = new Panel();
			DropPanel.BorderStyle = BorderStyle.FixedSingle;
			DropPanel.Height = 100;
			DropPanel.Visible = false;	
		}
		private void OnBtnClick(object sender, EventArgs e)
		{
			IsDropped = !IsDropped;
			_btn.Image = IsDropped ? Properties.Resources.DnPointer : Properties.Resources.RtPointer;
			DropPanel.Visible = IsDropped;
			DropPanel.BringToFront();	
		}
		internal void SetLocation()
		{
			// here we go up the chain of controls to determine where the location of the panel is
			// to be placed.
			Control c = _TB;
			Point offset = new Point(1, _TB.Height+2);
			while (c != DropPanel.Parent)
			{
				offset.X += c.Location.X;
				offset.Y += c.Location.Y;
				c = c.Parent;
			}
			DropPanel.Location = offset;
			
		}
		private void OnTBSizeChanged(object sender, EventArgs e)
		{
			DropPanel.Width = _TB.Width;
		}
	}

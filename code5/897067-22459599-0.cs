        #region Instance Variables
        ContextMenuStrip menuStrip = new System.Windows.Forms.ContextMenuStrip();
        public event EventHandler EntryComplete;
        public event EventHandler EntryNotComplete;
        public event EventHandler EntryError;
        #endregion
        // Control Constructor
        public AutoCompleteTextBox()
        {
            InitializeComponent();
            menuStrip.PreviewKeyDown += menuStrip_PreviewKeyDown;
            this.Leave += AutoCompleteTextBox_Leave;
            // Use closing event so that we can determine when to close the menustrip.
            menuStrip.Closing += new ToolStripDropDownClosingEventHandler(menuStrip_Closing);
        }
        void menuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            // only close the menu strip when an item is selected or the application loses focus
            if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked &&
                e.CloseReason != ToolStripDropDownCloseReason.AppFocusChange)
            {
                e.Cancel = true;
            }
        }
        private void AutoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            .
            .
            .
            try
            {
                // get information on whether a ToolbarMenuItem has been selected
                MenuItem info = new MenuItem();
                MenuItemInfo selectedToolStripMenuInfo = info.SelectedItem(menuStrip);
                menuStrip.AutoClose = true;
                menuStrip.Visible = false;
                menuStrip.Items.Clear();
                if (selectedToolStripMenuInfo == null)
                {
                    EntryNotComplete(sender, e);
                }
                if (base.Text.Length >= 3 && selectedToolStripMenuInfo == null)
                {
                    .
                    .
                    .
                    menuStrip.AutoClose = false;
                    // foreach loop to add items into list
                    foreach (SearchType item in lst)
                    {
                        szMenuItem = ...;
                        ToolStripItem tsItem = new ToolStripMenuItem();
                        tsItem.Text = szMenuItem;
                        tsItem.Name = item.DealId;
                        tsItem.Click += tsItem_Click;
                        tsItem.Font = new Font("Courier New", 8.0F, FontStyle.Italic);
                        menuStrip.Items.Add(tsItem);
                    }
                    Point point = base.Location;
                    point.Offset(2, base.Height + 2);
                    point = base.GetPositionFromCharIndex(base.SelectionStart);
                    point.Offset(2, base.Font.Height + 2);
                    base.ContextMenuStrip = menuStrip;
                    base.ContextMenuStrip.Show(base.PointToScreen(point));
                    base.Focus();
                    menuStrip.AutoClose = true;
                }
                else if (base.Text.Length >= 3 && selectedToolStripMenuInfo != null)
                {
                    EntryComplete(sender, e);
                }
            }
            catch (Exception ex)
            {
                ErrorDescription = ex.Message;
                menuStrip.AutoClose = true;
                menuStrip.Visible = false;
                EntryError(sender, e);
            }
        }

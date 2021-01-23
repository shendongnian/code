        public class CustomListView : ListView
        {
            public CustomListView()
            {
                cms.Items.AddRange(new ToolStripItem[]{ new ToolStripLabel("Test1"),new ToolStripLabel("Test2")});
                ContextMenuStrip = cms;
            }
            private bool ContextAllowed = false;
            private ContextMenuStrip cms = new ContextMenuStrip();
    
            public override ContextMenuStrip ContextMenuStrip
            {
                get
                {
                    return base.ContextMenuStrip;
                }
                set
                {
                    base.ContextMenuStrip = value;
                    base.ContextMenuStrip.Opening += ContextMenuStrip_Open;
                }
            }
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ListViewHitTestInfo test = HitTest(e.X, e.Y); //perform a hit test
                    if (test.Item != null) //if it hits an item, display the popup bar
                    {
                        ContextAllowed = true;
                        ContextMenuStrip.Show();
                    }
                }
                base.OnMouseDown(e);
            }
            protected override void OnMouseUp(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextAllowed = false; //close the menu
                }
                base.OnMouseUp(e);
            }
    
            private void ContextMenuStrip_Open(object sender, CancelEventArgs e)
            {
                if (!ContextAllowed)
                {
                    e.Cancel = true;
                }
            }
        }

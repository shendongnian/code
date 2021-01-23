        public Form1()
        {
            InitializeComponent();
            SourceListbox.DrawMode = DrawMode.OwnerDrawFixed;
            SourceListbox.DrawItem += SourceListbox_DrawItem;
        }
        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);
        private SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.Green);
        //custom method to draw the items, don't forget to set DrawMode of the ListBox to OwnerDrawFixed
        private void SourceListbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int index = e.Index;
            if (index >= 0 && index < SourceListbox.Items.Count)
            {
                string text = SourceListbox.Items[index].ToString();
                Graphics g = e.Graphics;
                //background:
                SolidBrush backgroundBrush;
                if (selected)
                    backgroundBrush = reportsBackgroundBrushSelected;
                else if (DestListbox.Items.Contains(SourceListbox.Items[index]))
                    backgroundBrush = reportsBackgroundBrush2;
                else
                    backgroundBrush = reportsBackgroundBrush1;
                g.FillRectangle(backgroundBrush, e.Bounds);
                //text:*/
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, SourceListbox.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }
        
        private void buttonCopySelected_Click(object sender, EventArgs e)
        {
            foreach (int idx in SourceListbox.SelectedIndices)
            {
                DestListbox.Items.Add(SourceListbox.Items[idx]);
            }
        }

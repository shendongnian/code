    public class CustomListView : ListView
    {
            public CustomListView(){
                SelectedIndices = new List<int>();
                OwnerDraw = true;
                DoubleBuffered = true;
            }
            public new List<int> SelectedIndices {get;set;}
            public int SelectedIndex { get; set; }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x1000 + 43) return;//LVM_SETITEMSTATE                
                else if (m.Msg == 0x201 || m.Msg == 0x202)//WM_LBUTTONDOWN and WM_LBUTTONUP
                {
                    int x = m.LParam.ToInt32() & 0x00ff;
                    int y = m.LParam.ToInt32() >> 16;
                    ListViewItem item = GetItemAt(x, y);
                    if (item != null)
                    {
                        if (ModifierKeys == Keys.Control)
                        {
                            if (!SelectedIndices.Contains(item.Index)) SelectedIndices.Add(item.Index);
                        }
                        else if (ModifierKeys == Keys.Shift)
                        {
                            for (int i = Math.Min(SelectedIndex, item.Index); i <= Math.Max(SelectedIndex, item.Index); i++)
                            {
                                if (!SelectedIndices.Contains(i)) SelectedIndices.Add(i);
                            }
                        }
                        else
                        {
                            SelectedIndices.Clear();
                            SelectedIndices.Add(item.Index);
                        }
                        SelectedIndex = item.Index;                        
                        return;
                    }                    
                }
                else if (m.Msg == 0x100)//WM_KEYDOWN
                {
                    Keys key = ((Keys)m.WParam.ToInt32() & Keys.KeyCode);
                    if (key == Keys.Down || key == Keys.Right)
                    {
                        SelectedIndex++;
                        SelectedIndices.Clear();
                        SelectedIndices.Add(SelectedIndex);
                    }
                    else if (key == Keys.Up || key == Keys.Left)
                    {
                        SelectedIndex--;
                        SelectedIndices.Clear();
                        SelectedIndices.Add(SelectedIndex);
                    }
                    if (SelectedIndex == VirtualListSize) SelectedIndex = VirtualListSize - 1;
                    if (SelectedIndex < 0) SelectedIndex = 0;
                    return;
                }
                base.WndProc(ref m);                
            }
            protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
            {
                e.DrawDefault = true;
                base.OnDrawColumnHeader(e);
            }
            protected override void OnDrawItem(DrawListViewItemEventArgs e)
            {
                i = 0;           
                base.OnDrawItem(e);
            }
            int i;
            protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
            {                
                if (!SelectedIndices.Contains(e.ItemIndex)) e.DrawDefault = true;
                else
                {
                    bool isItem = i == 0;
                    Rectangle iBound = FullRowSelect ? e.Bounds : isItem ? e.Item.GetBounds(ItemBoundsPortion.ItemOnly) : e.SubItem.Bounds;
                    Color iColor = FullRowSelect || isItem ? SystemColors.HighlightText : e.SubItem.ForeColor;
                    Rectangle focusBound = FullRowSelect ? e.Item.GetBounds(ItemBoundsPortion.Entire) : iBound;
                    if(FullRowSelect || isItem) e.Graphics.FillRectangle(SystemBrushes.Highlight, iBound);                    
                    TextRenderer.DrawText(e.Graphics, isItem ? e.Item.Text : e.SubItem.Text,
                        isItem ? e.Item.Font : e.SubItem.Font, iBound, iColor,
                        TextFormatFlags.LeftAndRightPadding | TextFormatFlags.VerticalCenter);
                    if(FullRowSelect || isItem) 
                    ControlPaint.DrawFocusRectangle(e.Graphics, focusBound);
                }
                i++;                
                base.OnDrawSubItem(e);
            }
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Add("Node1");
            this.treeView1.Nodes.Add("Node2");
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.FullRowSelect = true; this.treeView1.HideSelection = false; 
            this.treeView1.HotTracking = true;
            this.treeView1.ShowLines = false;
            this.treeView1.ForeColor = Color.Purple;
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView1.DrawNode += treeView1_DrawNode;
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color foreColor = e.Node.ForeColor;
            if (e.State == TreeNodeStates.Hot)
            {
                foreColor = Color.Red;
            }
            if (e.State == TreeNodeStates.Selected)
            {
                foreColor = SystemColors.HighlightText;
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, foreColor, Color.Red);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, Color.Red, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding);
            }
        }

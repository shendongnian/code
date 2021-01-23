    [Flags]
    public enum TreeViewDrawElements
    {
        FocusRect = 1,
        Selection = 2
    }
    public sealed class MyTreeView : TreeView
    {
        public MyTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            DrawElements = TreeViewDrawElements.FocusRect | TreeViewDrawElements.Selection;
        }
        [DefaultValue(TreeViewDrawElements.FocusRect | TreeViewDrawElements.Selection)]
        public TreeViewDrawElements DrawElements { get; set; }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            if (DrawElements == (TreeViewDrawElements.FocusRect | TreeViewDrawElements.Selection))
            {
                e.DrawDefault = true;
                return;
            }
            TreeNode node = e.Node;
            Rectangle bounds = node.Bounds;
            Graphics g = e.Graphics;
            Size textSize = TextRenderer.MeasureText(node.Text, node.TreeView.Font);
            Point textLoc = new Point(bounds.X - 1, bounds.Y); // required to center the text 
            bounds = new Rectangle(textLoc, new Size(textSize.Width, bounds.Height));
            Font font = node.NodeFont ?? node.TreeView.Font;
            bool selected = (DrawElements & TreeViewDrawElements.Selection) != 0 && (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            Color color = (selected && node.TreeView.Focused) ? SystemColors.HighlightText : (node.ForeColor != Color.Empty) ? node.ForeColor : node.TreeView.ForeColor;
            g.FillRectangle(selected ? SystemBrushes.Highlight : SystemBrushes.Window, bounds);
            if ((DrawElements & TreeViewDrawElements.FocusRect) != 0 && (e.State & TreeNodeStates.Selected) != 0)
                ControlPaint.DrawFocusRectangle(g, bounds, color, SystemColors.Highlight);
            TextRenderer.DrawText(g, e.Node.Text, font, bounds, color, TextFormatFlags.Default);
        }
    }

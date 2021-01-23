    //define the icon file path
        string minusPath = Application.StartupPath + Path.DirectorySeparatorChar + "minus.png";
        string plusPath = Application.StartupPath + Path.DirectorySeparatorChar + "plus.png";
        string nodePath = Application.StartupPath + Path.DirectorySeparatorChar + "directory.png";
        public FrmTreeView()
        {
            InitializeComponent();
            //setting to customer draw
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }
        void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = e.Node.Bounds;
            /*--------- 1. draw expand/collapse icon ---------*/
            Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
            Image expandImg = null;
            if (e.Node.IsExpanded || e.Node.Nodes.Count < 1)
                expandImg = Image.FromFile(minusPath);
            else
                expandImg = Image.FromFile(plusPath);
            Graphics g = Graphics.FromImage(expandImg);
            IntPtr imgPtr = g.GetHdc();
            g.ReleaseHdc();
            e.Graphics.DrawImage(expandImg, ptExpand);
            /*--------- 2. draw node icon ---------*/
            Point ptNodeIcon = new Point(nodeRect.Location.X - 4, nodeRect.Location.Y + 2);
            Image nodeImg = Image.FromFile(nodePath);
            g = Graphics.FromImage(nodeImg);
            imgPtr = g.GetHdc();
            g.ReleaseHdc();
            e.Graphics.DrawImage(nodeImg, ptNodeIcon);
            /*--------- 3. draw node text ---------*/
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null)
                nodeFont = ((TreeView)sender).Font;
            Brush textBrush = SystemBrushes.WindowText;
            //to highlight the text when selected
            if ((e.State & TreeNodeStates.Focused) != 0)
                textBrush = SystemBrushes.HotTrack;
            //Inflate to not be cut
            Rectangle textRect = nodeRect;
            //need to extend node rect
            textRect.Width += 40;
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, Rectangle.Inflate(textRect, -12, 0));
         }

    using System.Windows.Forms.VisualStyles;
    //..
    public partial class UcTreeView : TreeView
    {
        [DisplayName("Checkbox Spacing"),  CategoryAttribute("Appearance"),
         Description("Number of pixels between the checkboxes.")]
        public int Spacing { get; set; }
        [DisplayName("Text Padding"), CategoryAttribute("Appearance"), 
         Description("Left padding of text.")]
        public int LeftPadding { get; set; }
        public UcTreeView()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            CheckBoxes = false;       // necessary!
            FullRowSelect = false;    // necessary!
            Spacing = 4;              // default cell spacing
            LeftPadding = 7;          // default text padding
        }
        public TreeNode3 AddNode(string label, bool check1, bool check2, bool check3)
        {
            TreeNode3 node = new TreeNode3(label, check1, check2, check3);
            this.Nodes.Add(node);
            return node;
        }
        
        private  Size glyph = Size.Empty;
     
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            TreeNode3 n = e.Node as TreeNode3;
            if (n == null) { e.DrawDefault = true; return; }
            CheckBoxState cbyTrue = CheckBoxState.CheckedNormal;
            CheckBoxState cbyFalse = CheckBoxState.UncheckedNormal;
            Rectangle rect = new Rectangle(e.Bounds.Location, 
                                 new Size(ClientSize.Width, e.Bounds.Height));
            glyph = CheckBoxRenderer.GetGlyphSize(e.Graphics, cbyTrue );
            int offset = glyph.Width * 3 + Spacing * 2 + LeftPadding;
            bool selected = n.IsSelected;
            if (selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.MenuHighlight ,rect);
                e.Graphics.DrawString(n.Label, Font, Brushes.White, 
                                      e.Bounds.X + offset, e.Bounds.Y);
            }
            else
            {
                CheckBoxRenderer.DrawParentBackground(e.Graphics, e.Bounds, this);
                e.Graphics.DrawString(n.Label, Font, Brushes.Black, 
                                      e.Bounds.X + offset, e.Bounds.Y);
            }
            CheckBoxState bs1 = n.Check1 ? cbyTrue : cbyFalse;
            CheckBoxState bs2 = n.Check2 ? cbyTrue : cbyFalse;
            CheckBoxState bs3 = n.Check3 ? cbyTrue : cbyFalse;
            CheckBoxRenderer.DrawCheckBox(e.Graphics,  cbx(e.Bounds, 0).Location, bs1);
            CheckBoxRenderer.DrawCheckBox(e.Graphics,  cbx(e.Bounds, 1).Location, bs2);
            CheckBoxRenderer.DrawCheckBox(e.Graphics,  cbx(e.Bounds, 2).Location, bs3);
        }
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            Console.WriteLine(e.Location + " bounds:"  + e.Node.Bounds);
            TreeNode3 n = e.Node as TreeNode3;
            if (e == null) return;
            TreeNode nSel = SelectedNode;
            if      (cbx(n.Bounds, 0).Contains(e.Location)) n.Check1 = !n.Check1;
            else if (cbx(n.Bounds, 1).Contains(e.Location)) n.Check2 = !n.Check2;
            else if (cbx(n.Bounds, 2).Contains(e.Location)) n.Check3 = !n.Check3;
            else
            {
                if (nSel == n && Control.ModifierKeys == Keys.Control)
                     SelectedNode = SelectedNode != null ? null : n;
                else SelectedNode = n;
            }
            Console.WriteLine(" " + n.Check1 + " " + n.Check2 +" " + n.Check3 );
            Invalidate();
        }
        Rectangle cbx(Rectangle bounds, int check)
        {
            return new Rectangle(bounds.Left + 2 + (glyph.Width + Spacing) * check, 
                                 bounds.Y + 2, glyph.Width, glyph.Height);
        }
    }

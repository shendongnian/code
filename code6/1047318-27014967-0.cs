    public partial class Form1 : Form
    {
        Point clickedPoint;
        bool mouseDown = false;
        public Form1()
        {
            InitializeComponent();
            radTextBox1.TextBoxElement.TextBoxItem.HostedControl.AllowDrop = true;
            radTextBox1.TextBoxElement.TextBoxItem.HostedControl.DragEnter += new DragEventHandler(HostedControl_DragEnter);
            radTextBox1.TextBoxElement.TextBoxItem.HostedControl.DragDrop += new DragEventHandler(HostedControl_DragDrop);
            
            radTreeView1.MouseDown += new MouseEventHandler(radTreeView1_MouseDown);
            radTreeView1.MouseMove += new MouseEventHandler(radTreeView1_MouseMove);
            
        }
        void HostedControl_DragDrop(object sender, DragEventArgs e)
        {
            RadTreeNode node = e.Data.GetData(typeof(RadTreeNode)) as RadTreeNode;
            if (node != null)
            {
                radTextBox1.Text = node.Text;
            }
        }
        void HostedControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        void radTreeView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && IsRealDrag(e.Location, clickedPoint))
            {
                TreeNodeElement node = ((RadTreeView)sender).ElementTree.GetElementAtPoint(clickedPoint) as TreeNodeElement;
                if (node != null)
                {
                    ((RadTreeView)sender).DoDragDrop(node.Data, DragDropEffects.Copy | DragDropEffects.Move);
                }
                mouseDown = false;
            }
        }
        void radTreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = true;
                clickedPoint = e.Location;
            }
        }
        private static bool IsRealDrag(Point mousePosition, Point initialMousePosition)
        {
            return (Math.Abs(mousePosition.X - initialMousePosition.X) >= SystemInformation.DragSize.Width) ||
                (Math.Abs(mousePosition.Y - initialMousePosition.Y) >= SystemInformation.DragSize.Height);
        }
    }

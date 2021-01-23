    public class Movable : Control
    {
        public Panel ContainerPanel { get; set; }    
        public Movable(Point location, Size size) : base()
        {
            var pan = new Panel();
            pan.Margin = new Padding(0);
            pan.Padding = new Padding(0);
            pan.Location = location;
            pan.Size = size;
            this.ContainerPanel = pan;
            this.Location = new Point(0, 0);
            this.Size = size;
            pan.Controls.Add(this);
            pan.Height = size.Height; // Resize again after addition of 'content'
            this.movable = isMovable;
        }
        // codes for OnMouseDown, OnMouseUp, OnMouseMove, ...
    }
    public class MovableTest : Movable
    {
        public MovableTest(Point location, Size size)
            : base(location, size) { }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            // user drawing code comes here
        }
    }
    public partial class Form1 : Form
    {
        MovableTest ctrl2;
        ctrl2 = new MovableTest(new Point(75, 50), new Size(100, 100));
        
        // add .ContainerPanel, NOT ctrl2 itself!
        this.Controls.Add(ctrl2.ContainerPanel); 
    }

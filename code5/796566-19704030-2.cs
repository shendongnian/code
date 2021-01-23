    public class MyControl : ToolStripMenuItem
    {
        public MyControl(){}
        public MyControl(string text, Image image ):base (text,image){}
        public MyControl(string text):base(text){}
        public MyControl(Image image):base(image){}
        public MyControl(string text,Image image,EventHandler onClick):base(text,image,onClick){}
        public MyControl(string text, Image image,int id):base(text,image){  this.ID = id;}
        public MyControl(string text,Image image,int id,EventHandler onClick):base(text,image,onClick){this.ID = id; }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (base.Checked == false)
            {
               Rectangle rect = new Rectangle(this.Width - 20, 1, 20, 20);               
                e.Graphics.DrawImage(Properties.Resources.BlackStar, rect);
            }
            else
            { 
                Rectangle rect = new Rectangle(this.Width - 20, 1, 20, 20);
                e.Graphics.DrawImage(Properties.Resources.YellowStar, rect);
            }
        }
        public int ID { get; set; }
        public bool StarClicked { get; set; }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {            
            StarClicked = e.X > (this.Width - 20);
            if (StarClicked)
            {
                this.Checked = this.Checked == true ? false : true;
            }
            else
                base.OnClick(e);
            base.OnMouseDown(e);
        }

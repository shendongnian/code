    int itemIndex = -1;
    public Form1()
    {
      InitializeComponent();
      this.listBox1.DrawItem += new            
              System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
    }
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
    	e.DrawBackground();
    	Graphics g = e.Graphics;
    	if(e.Index == itemIndex )
    	{
    		g.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
    	}
    	else
    	{
    		g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
    	}
    	ListBox lb = (ListBox)sender;
    	g.DrawString(listBox1.Items[e.Index].ToString(), e.Font,
    	      new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
    	e.DrawFocusRectangle();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        setcolor(int.Parse(textBox1.Text));
    }
    
    void setcolor(int index)
    { 
    	itemIndex = index;
    	listBox1.DrawMode = DrawMode.Normal;
    	listBox1.DrawMode = DrawMode.OwnerDrawFixed;
    }

    public partial class Form1 : Form {
    	private Dictionary<PictureBox, Bitmap> bitmaps = new Dictionary<PictureBox,Bitmap>(); 
    	public Form1() {
    		InitializeComponent();
    		bitmaps.Add(pictureBox1, mybitmap1);
    		bitmaps.Add(pictureBox2, mybitmap2);
    
    	}
    	
    	private void pictureBox_Paint(object sender, PaintEventArgs e) {
    		PictureBox pb = sender as PictureBox;
    		if (pb == null) {
    			return;
    		}
    		e.Graphics.Clear(System.Drawing.Color.Black);    
    		e.Graphics.DrawImage(bitmaps[pb], X, Y); 
    		e.Graphics.DrawLine(mypen, verticalstart, verticalend);//Draw Vertical line.
    	}
    }

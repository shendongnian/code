    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	Bitmap _icopalABitmap = KaminuSkaiciuokle.Properties.Resources.IcopalA;
    	Bitmap _icopalBBitmap = KaminuSkaiciuokle.Properties.Resources.IcopalB;
    
    	private void pictureBox1_Click(object sender, EventArgs e)
    	{            
    		if (pictureBox7.Image == _icopalABitmap)
    		{
    			pictureBox7.Image = _icopalBBitmap;
    		}
    		else
    		{
    			pictureBox7.Image = _icopalABitmap;
    		}
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		pictureBox7.Image = _icopalABitmap;
    	}
    }

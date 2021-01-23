    using System.Windows.Forms;
    public static void Main()
    {	
    	var image = new PictureBox();
        image.Dock = DockStyle.Fill;    	
        image.Load(@"img.jpg");
    	var f = new Form();
    	f.Controls.Add(image);    	
    	Application.Run(f);
    }

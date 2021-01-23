    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    
        namespace WindowsFormsApplication6
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                    var myAssembly = Assembly.GetExecutingAssembly();
                    var myStream = myAssembly.GetManifestResourceStream("WindowsFormsApplication6.Desert.jpg");
                    var image = new Bitmap(myStream);
        
                    pictureBox1.Image = image;
                }
            }
        }

    using Emgu.CV;
    using Emgu.CV.UI;
    using Emgu.CV.Structure;
    using System.Drawing;
    using System.Windows.Forms;
    ...
     
    ImageViewer viewer = new ImageViewer(); //create an image viewer
    Capture capture = new Capture(); //create a camera captue
    Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
    {  //run this until application closed (close button click on image viewer)
       viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
    });
    viewer.ShowDialog(); //show the image viewer

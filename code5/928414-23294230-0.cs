    public partial class Form3 : Form {
        string[] imageFilenames = new string[] {
            "C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic1.jpg",
            "C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic2.jpg",
            "C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic3.jpg",
            "C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic4.jpg",
            "C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic5.jpg",
        };
        int btnClick=0;
        
        private void button1_Click(object sender, EventArgs e) {
            btnClick++;
            pictureBox1.Image = Image.FromFile(imageFilenames[imageFilenames.Count % btnClick]);
        }
    }

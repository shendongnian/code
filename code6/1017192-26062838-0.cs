      public partial class Form1 : Form
    {
       public static WebCam camera = new WebCam();
        private void button1_Click(object sender, EventArgs e)
        {
           if (!camera.IsConnected())
                {
                    camera.Connect();
                    camera.Update();
                    MemoryStream ms = new MemoryStream();
                    camera.CalcBitmap().Save(ms, ImageFormat.Bmp);
                    byte[] bitmapData = ms.ToArray();
                    MemoryStream stream = new MemoryStream(bitmapData);
                    pictureBox1.Image = new Bitmap(stream);
                }
                else
                {
                    Application.Exit();
                }
        }
        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e) {
            ImageFormatter formatter = new ImageFormatter();
            Image output = formatter.GetCanvasedImage(
                @"C:\Development\input.jpg"
            );
            output.Save(
                @"C:\Development\output.jpg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
        }

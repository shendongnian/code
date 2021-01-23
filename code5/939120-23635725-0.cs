    private void button4_Click(object sender, EventArgs e)
    {
                Image img = Image.FromFile(previewFileName);
                int width = img.Width;
                int height = img.Height;
                int dirsnumbers = (int)Math.Floor(width / numeric);
                for (int i = 0; i <= dirsnumbers; i++)
                {
                    path = Path.Combine(@"c:\temp\newimages",
            String.Concat("SecondProcess_", DateTime.Now.ToString("MMddyyyy-HHmmss")) + 
                         "-" + "Width = " + (width - numeric) + " Height = " + (height - numeric) );
                    Directory.CreateDirectory(path);
                }
    }

     public void GetImageData(string BitmapName, TextBox ImageName, TextBox ImageCreated, TextBox Size, TextBox Width, TextBox Height, TextBox HResolution, TextBox VResolution, TextBox Type, PictureBox Preview)
        {
          try
          {
            FileInfo fileinfo = new FileInfo(BitmapName);
            ImageName.Text = fileinfo.Name;
            ImageCreated.Text = fileinfo.CreationTime.ToString();
            Size.Text = (fileinfo.Length / 1024).ToString() + " Kilobytes";
            Image image = Image.FromFile(BitmapName);
            using (Bitmap Bit = new Bitmap(image))
            {
              Height.Text = Bit.Height.ToString() + " px";
              Width.Text = Bit.Width.ToString() + " px";
              HResolution.Text = Bit.HorizontalResolution.ToString() + " dpi";
              VResolution.Text = Bit.VerticalResolution.ToString() + " dpi";
              if (fileinfo.Extension == ".bmp" || fileinfo.Extension == ".BMP")
              {
                Type.Text = "Bitmap Image";
              }
              else if (fileinfo.Extension == ".jpeg" || fileinfo.Extension == ".JPEG")
              {
                Type.Text = "Jpeg Image";
              }
              else if (fileinfo.Extension == ".jpg" || fileinfo.Extension == ".JPG")
              {
                Type.Text = "Jpg Image";
              }
              else if (fileinfo.Extension == ".png" || fileinfo.Extension == ".PNG")
              {
                Type.Text = "Png Image";
              }
              else if (fileinfo.Extension == ".gif" || fileinfo.Extension == ".GIF")
              {
                Type.Text = "GIF Image";
              }
              if (Preview.Image != null)
                Preview.Image.Dispose();
              Preview.Image = image;
            }
          }
          catch (OutOfMemoryException)
          {
            Preview.Image = Properties.Resources.InvalidImage;
          }
        }

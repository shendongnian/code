        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //Save any type of format you want, like jpeg, png,gif etc
            return ms.ToArray();
        }

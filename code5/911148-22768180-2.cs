        public static readonly PictureBox box = CreatePicturebox();
        public static PictureBox CreatePicturebox()
        {
            PictureBox box = new PictureBox();
            box.Value = "sample";
            return box;
        }

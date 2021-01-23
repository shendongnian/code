    public class clsAlbum
    {
        public string album_name { get; set; }
        public string album_img { get; set; }
        public string album_img_src 
        {
            get
            {
                 return @"/Assets/Images/" + album_img;
            }
        }
    }

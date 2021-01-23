    abstract class BaseClass
    {
        public static Texture TextureImage { get; set; }
        public Texture LoadTexture(string path)
        {
             //return some texture using path,
        }
    }
    class AChild : BaseClass
    {
        private static Texture TextureImageA { get; set; }
        public override Texture TextureImage 
        {
            get { return TextureImageA; }
            set { TextureImageA = value; }
        }
        AChild()
        {
             if (TextureImage == null)
                 TextureImage = LoadTexture(PathToImageA);
        }
    }
    class BChild : BaseClass
    {
        private static Texture TextureImageB { get; set; }
        public override Texture TextureImage 
        {
            get { return TextureImageB; }
            set { TextureImageB = value; }
        }
        BChild()
        {
             if (TextureImage == null)
                 TextureImage = LoadTexture(PathToImageB);
        }
    }

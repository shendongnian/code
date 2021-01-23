    abstract class BaseClass
    {
        public static Texture TextureImage { get; set; }
    }
    class AChild : BaseClass
    {
        static AChild()
        {
             if (TextureImage == null)
                 TextureImage = LoadTexture(PathToImageA);
        }
    }
    class BChild : BaseClass
    {
        static BChild()
        {
             if (TextureImage == null)
                 TextureImage = LoadTexture(PathToImageB);
        }
    }
    Main()
    {
         var aOne = new AChild();
         var aTwo = new AChild();
         var bOne = new BChild();
         var bTwo = new BChild();
    }

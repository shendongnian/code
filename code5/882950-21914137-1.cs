    abstract class BaseClass
    {
        public abstract Texture TextureImage { get; }
        private Texture _TextureImage;
    }
    class AChild : BaseClass
    {
        public override Texture TextureImage {
            get {
              if ( _TextureImage == null )
                  _TextureImage = LoadTexture(PathToImageA);
              return _TextureImage;
            }
        }
    }
    class BChild : BaseClass
    {
        public override Texture TextureImage {
            get {
              if ( _TextureImage == null )
                  _TextureImage = LoadTexture(PathToImageB);
              return _TextureImage;
            }
        }
    }
    Main()
    {
         var aOne = new AChild();
         var aTwo = new AChild();
         var bOne = new BChild();
         var bTwo = new BChild();
    }

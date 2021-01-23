    class Program
    {
        static void Main(string[] args)
        {
            AChild a1 = new AChild();
            Console.WriteLine(a1.TextureImage.Path);
            BChild b = new BChild();
            Console.WriteLine(b.TextureImage.Path);
            AChild a2 = new AChild();
            Console.WriteLine(a2.TextureImage.Path);
        }
    }
    
    public class Texture
    {
        public string Path { get; set; }
    
    }
    
    public abstract class BaseClass
    {
        public static ConcurrentDictionary<Type, Texture> TextureImageCache { get; set; }
    
        static BaseClass()
        {
            TextureImageCache = new ConcurrentDictionary<Type, Texture>();
        }
    
        public virtual Texture TextureImage
        {
            get
            {
                return TextureImageCache.GetOrAdd(
                    this.GetType(),
                    t => this.LoadTexture(this.TexturePath));
            }
        }
    
        public Texture LoadTexture(string path)
        {
            return new Texture { Path = path };
        }
    
        public abstract string TexturePath { get; }
    }
    
    public class AChild : BaseClass
    {
    
        public override string TexturePath
        {
            get { return "iamgeA"; }
        }
    }
    
    public class BChild : BaseClass
    {
    
        public override string TexturePath
        {
            get { return "imageB"; }
        }
    }

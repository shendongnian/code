    public interface IContent {
        object GetContent();
    }
    public abstract class Content<T> : IContent {
        public abstract T GetContent();
        object IContent.GetContent() 
        {
            return this.GetContent(); // Calls the generic GetContent method.
        }
    }
    
    public class UrlContent : Content<String>  {
        public String s;
        public override String GetContent() { return s; }
    }
    
    public class ImageContent : Content<Byte[]>  {
        public Byte[] image;
        public override Byte[] GetContent(){ return image; }
    }

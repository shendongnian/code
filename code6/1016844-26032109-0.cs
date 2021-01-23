    public interface FileParser<T>
    {
        string Parse(T value);
    }
    public class UriParser : FileParser<Uri>
    {
        string Parse(Uri value)
        {
            // implementation
        }
    }

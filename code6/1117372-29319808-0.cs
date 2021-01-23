    public enum category
    {
        LocalNews,
        Sport
    }
    public class article
    {
        public string id;
        public string title;
        public string body;
        public string imageId;
        public category category;
        public int eyecatchingness;
        public bool archived;
    }
    public class image
    {
        public string id;
        public string title;
        public string description;
        public string filename;
    }
    public abstract class sidebarItem
    {
        public string id;
        public category category;
        public string mainArticleId;
    }
    public abstract class sidebarItemImage : sidebarItem
    {
        public string imageId;
    }
    public abstract class sidebarItemTitle : sidebarItem
    {
        public string title;
    }
    public abstract class sidebarItemParagraph : sidebarItem
    {
        public string paragraph;
    }

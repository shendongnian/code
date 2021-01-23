    public interface ITag
    {
        void WriteTag(string tagName = null);
    }
    public class BaseTag :ITag
    {
        public virtual void WriteTag(string tagName = null)
        {
            if (tagName == null)
                tagName = "BaseTag";
            Console.WriteLine(tagName); 
        }
    }
    public class SubTag : BaseTag
    {
        public override void WriteTag(string tagName = null)
        {
            if (tagName == null)
                tagName = "SubTag";
            
            Console.WriteLine(tagName);
        }
    }

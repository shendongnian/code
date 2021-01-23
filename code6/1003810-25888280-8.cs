    public class Version : BaseObject
    {
        public virtual ICollection<SER> ListOfSER { get; set; }
    }
    public abstract class AbstractR : BaseObject
    {
    }
    public class SER : AbstractR
    {
        public int VersionId { get; set; }
        public virtual Version Version { get; set; }
    }

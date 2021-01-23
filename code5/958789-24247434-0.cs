    using System.Runtime.Serialization;
    [KnownType(typeof(DatabaseSource))]
    [KnownType(typeof(WebSource))]
    public abstract class AbstractSource
    {
        public string name { get; set; }
    }

    public interface IHasElementName
    {
        string ElementName { get; set; }
    }
    public class Property : IHasElementName
    {
        [XmlIgnore]
        public string name; //could be enum
        public int id;
        public string value;
        #region IHasElementName Members
        [XmlIgnore]
        string IHasElementName.ElementName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        #endregion
    }

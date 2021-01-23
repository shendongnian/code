    public partial class ProductDefinition
    {
        [XmlIgnore]
        public ArrayList ruleSetArrayList
        {
            get
            {
                return new ArrayList(ruleSet);
            }
        }     
    }

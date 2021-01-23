    [Serializable()]
    public  class CollectionList<T> : IList<T>
    {
      
       private XmlSerializer ser;
       private List<T> InnerList = new List<T>();
       
       
       #region ctor
       public CollectionList(string CollectionName)
       {
           ser = new XmlSerializer(this.GetType(), new XmlRootAttribute(CollectionName ));
       }
    ....

    [Serializable]
    public class GenericListContainer<T> where T : class
    {
        #region Constructors
        public GenericListContainer()
        {
           
        }
        public GenericListContainer(IEnumerable<T> list)
        {
            List = list;
        }
        #endregion
        #region Properties
        public IEnumerable<T> List { get; set; }
               
        #endregion
    }

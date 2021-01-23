    public class Father
    {
        public int Id { get; set; }
        
        #region Navigations Properties
        public virtual List<Child> Childs { get; set; }
        #endregion
    }

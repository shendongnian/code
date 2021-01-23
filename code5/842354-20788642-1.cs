    public class Store
    {
        ...
        // not public
        protected virtual IList<Employee> Staff { get; set; }
        // here we do the trick on top of the mapping/hidden persistence layer
        public virtual Employee Employee 
        { 
           get { return Staff.FirstOrDefault(); }
           set { Staff[0] = value ; }

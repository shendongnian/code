    public interface IResults
    {
         //other fields
        ISearch SearchControl { get; set; }
    }
    public partial class Results : IResults
    {
         //other fields
    
         private ISearch searchControl;
         public ISearch SearchControl
         {
    
            get
            {
                return this.searchControl;
            }
            set
            {
                if (this.SearchControl != null)
                {
                    // remove event here
                }
                this.searchControl = value;
                this.SearchControl.OnSearch += new EventHandler(testMethod);
         }
    }

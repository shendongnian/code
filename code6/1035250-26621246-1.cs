    public class ServiceXYZ : IServiceXYZ
    {
        // XYZ.Data persistence object
        public void Insert(BaseClass entity)
        {
            //get EF Context 
            var Context = GetContext();  // <-- some method to get your EF context
            Context.Entity(entity).State = Added;  //<- this will attach and add         
        }

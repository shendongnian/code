    public class Program
    {
        private static void Main(string[] args)
        {
        }
        
        protected void b_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //process something based on the e.PropertyName 
            //might call some private or protected methods here to help with the processing
        }
    
    }
    
    public class TestableProgram : Program
    {
        public new void b_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.b_PropertyChanged(sender, e);
        }
    }

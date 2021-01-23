    public static Helper
    {
        public static void FactoryFaulted(object sender, EventArgs e)
        {
            ChannelFactory factory = (ChannelFactory)sender;
    
            try
            {
                factory.Close();
            }
            catch
            {
                factory.Abort();
            }
        }
    }
    
    public class YourClass
    {
       public void DoSomethind()
       {
           Helper.FactoryFaulted(null, null);
       }
    }

    public class SamplePlugin : MarshalByRefObject, IPlugin
    {
        public void Do()
        {
            using (AppDb db = new AppDb())
            {
                db.Posts.FirstOrDefault();
            }
        }
    }
    

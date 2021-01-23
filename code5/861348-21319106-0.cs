    public class ContentManager : IDisposable
    {
        private List<int> idlist = new List<int>();
        private static ContentManager instance;
    
        private ContentManager () {}
    
        public static ContentManager Instance
        {
           get 
           {
               if (instance == null)
               {
                   instance = new ContentManager ();
               }
               return instance;
           }
        }
    
        public int Load(string path)
        {
            int id = LoadFile(myfilecontent);    
            idlist.Add(id);
            return id;
        }
    
        public void Dispose()
        {
            foreach(int id in idlist)
            {
                DeleteContent(id);
            }
        }
    }

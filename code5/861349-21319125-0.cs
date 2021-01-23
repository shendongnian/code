     class ContentManager : IDisposable
     {
            List<int> idlist = new List<int>();
    
            static ContentManager instance=null;
    
            ContentManager()
            {
            }
    
            public static ContentManager Instance
            {
                get
                {
                    if (instance==null)
                    {
                        instance = new ContentManager();
                    }
                    return instance;
                }
            }
    
            public int Load(string path)
            {
                //Load file, give content, gets an id
    
                //...
    
                int id = LoadFile(myfilecontent);
    
                idlist.Add(id);
                return id;
            }
    
            public void Dispose()
            {
                //Delete the given content by id, stored in idlist
    
                foreach (int id in idlist)
                {
                    DeleteContent(id);
                }
            }
     }

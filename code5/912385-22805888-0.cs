       interface  ICustomCache
       {
           bool IsFound(string key, out object value); 
            void Set(string key, object value); the set should replace the old object
        }
        public class SQLCustomCache:ICustomCache
        {
            #region ICustomCache Members
    
            public bool IsFound(string key, out object value)
            {
                "Your Implementation for cheking in SQl";
            }
    
            public void Set(string key, object value)
            {
                "Your Implementation for Storing it in SQl";
            }
    
            #endregion
        }
        public class FileSystemCustomCache : ICustomCache
        {
            #region ICustomCache Members
    
            public bool IsFound(string key, out object value)
            {
                "Your Implementation for cheking  in FileSystem";
            }
    
            public void Set(string key, object value)
            {
                "Your Implementation for Storing it in FileSystem";
            }
    
            #endregion
        }
        public class CustomCache
        {
            static ICustomCache mycacheObject = null;
    
            #region ICustomCache Members
            private CustomCache()
            { 
            
            }
    
            public ICustomCache GetCustomCacheInstance(string Type)
            {
                if(mycacheObject==null)
                {
                    if (Type == "SQL")
                    {
                        mycacheObject = new SQLCustomCache();
                    }
                    else
                    {
                        mycacheObject = new FileSystemCustomCache();
                    }
                }
                return mycacheObject;
    
            }        
        }

        public static bool VerifyDoublePost(string Hash, System.Web.Caching.Cache cache)
        {
            string key = "Post_" + Hash;
            if (cache[key] == null)
            {
                cache.Insert(key, true, null, DateTime.Now.AddDays(1), TimeSpan.Zero);
                return false;
            }
            else
            {
                return true;
            }
        }

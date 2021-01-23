        private static string lockUri = "";
        public override Uri MapUri(Uri uri)
        {
            lock (lockUri)
            {
                if (lockUri != uri.ToString())
                {
                    lockUri = uri.ToString();
                    return null;
                }
            }
            // Your code to route here
        }

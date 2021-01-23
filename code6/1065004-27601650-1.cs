        public void Method1()
        {
            Method2(1, ex => SendEmail(ex));
        }
        public IEnumerable<int> Method2(int id, Action<Exception> callback)
        {
            foreach (var i in new List<int>())
            {
                try
                {
                    /*Do some stuff*/
                }
                catch(Exception ex)
                {
                    callback(ex);
                }
                yield return i;
            }
        }
        private void SendEmail(Exception ex)
        {
            // blah
        }

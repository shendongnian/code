    class Dependant
    {
        public Dependant(ILog[] logs)
        {
            foreach (var i in Enumerable.Range(1, 15))
            {
                foreach (var log in logs)
                    log.Log(string.Format("{0} - going to FS", i));
            }   
        }
    }

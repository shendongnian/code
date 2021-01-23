    class Program
    {
        private static List<Dictionary<string, Guid>> GetList()
        {
            var myList = new List<Dictionary<string, Guid>>();
            for (var i = 0; i < 25; i++)
            {
                var newDict = new Dictionary<string, Guid>();
                for (var j = 0; j < 25; j++)
                {
                    newDict.Add(j.ToString(), Guid.NewGuid());
                }
                myList.Add(newDict);
            }
            return myList;
        }
        //Really, I want the following to use interfaces; lets not worry about why there is a middle-man function.
        private static IList<Dictionary<string, Guid>> MyIntermediateFuncForAReason() 
        {
            var originalList = GetList();
            //whatever processing.
            return originalList;
        }
        static void Main(string[] args)
        {
            var t = MyIntermediateFuncForAReason();
            // whatever...
        }
    }

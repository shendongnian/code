    IList<T> GetRandomElements(this IList<T> me, int numElements)
    {
        var copyOfMe = new List<T>(me);
        List<T> results = new List<T>();
        Random rnd = new Random();
        for(int i=0; i<numElements;i++)
        {
            if(copyOfMe.Count > 0)
            {
                int index = Random.Next(0,results.Count);
                results.Add(copyOfMe[index]);
                copyOfMe.Remove(index);
            }
        }
    }

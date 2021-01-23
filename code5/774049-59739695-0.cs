    public int solution(int X, int[] A) {
            Hashtable spaces = new Hashtable();
            int counter = 0;
            foreach(int i in A)
            {
                //Don't insert duplicate keys OR 
                //keys greater than requested path length
                if (!spaces.ContainsKey(i) && i <= X)
                    spaces.Add(i, i);
                //If Hashtable contents count = requested number of leaves,
                //then we're done
                if (spaces.Count == X)
                    return (counter);
                counter++;
            }
            
            return -1;
    }

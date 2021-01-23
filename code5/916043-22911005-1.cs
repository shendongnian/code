    public class myClass
    {
        List<First> firstItems;
        List<Second> secondItems;
    
        public int SearchOf(First pattern)
        {
            return SearchOf(pattern, firstItems);
        }
    
        public int SearchOf(Second pattern)
        {
            return SearchOf(pattern, secondItems);
        }
    
        private static int SearchOf<T>(T pattern, IList<T> searched) where T : IIdent
        {
            for (int index = 0; index < searched.Count; index++)
                if (pattern.Id == searched[index].Id)
                    return index;
            return -1;
        }
    }

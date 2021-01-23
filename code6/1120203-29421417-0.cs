        public class TheType
        {
            public IList<IList<string>> arrayOfArraysOfIds;
            public bool ContainsAny(IList<string> listOfIds)
            {
                return arrayOfArraysOfIds.Contains(listOfIds);
            }
        }
       theCollection.AsQueryable<TheType>().Where(t => t.ContainsAny(listOfIds));

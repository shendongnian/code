    class Program
    {
        static void Main(string[] args)
        {
            List<int> searchListIds = new List<int>
            {
                1,
                2,
            };
            List<int> searchListFieldValues = new List<int>
            {
                100,
                50,
            };
            List<Tuple<int, int>> searchParameters = new List<Tuple<int,int>>();
            for (int i = 0; i < searchListIds.Count; i++)
            {
                searchParameters.Add(new Tuple<int,int>(searchListIds[i], searchListFieldValues[i]));
            }
            List<AdField> adFields = new List<AdField>
            {
                new AdField(1, 1, 1, 100),
                new AdField(2, 2, 1, 100),
                new AdField(3, 1, 2, 50),
                new AdField(4, 2, 2, 50),
                new AdField(5, 3, 1, 100),
                new AdField(6, 3, 2, 49),
                new AdField(7, 3, 3, 10)
            };
            var result = adFields.Where(af => searchParameters.Any(sp => af.ListId == sp.Item1 && af.ListFieldValue < sp.Item2)).Select(af => af.AdId).Distinct();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
        public class AdField
        {
            public int Id { get; private set; }
            public int AdId { get; private set; }
            public int ListId { get; private set; }
            public int ListFieldValue { get; private set; }
            public AdField(int id, int adId, int listId, int listFieldValue)
            {
                Id = id;
                AdId = adId;
                ListId = listId;
                ListFieldValue = listFieldValue;
            }
        }
    }

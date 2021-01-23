    public interface IPerson
    {
        string name {get;set;}
        int age {get;set;}
        Kids kids {get;}
        Occupation Occupation {get;}
        void AddKid(string name);
    }
    
    public class Person : IPerson 
    {
        [Key]
        public int PersonID{get;set}
        public string name {get;set;}
        public int age {get;set;}
        [NotMapped]
        public Kids kids { get
            {
                Kids k = new Kids
                {
                    namesOfKids = (new [] 
                    {
                        Name1,
                        Name2,
                        Name3,
                        // ...
                    }).Where(n => n != null).ToList();
                };
                k.numberOfKids = k.namesOfKids.Count;
                return k;
            }
        }
        public int numberOfKids{get; set;}
        public List<string> namesOfKids{get; set;}
        public int OccupationID{get;set;}
        [NotMapped]
        public Occupation Occupation {get { // TODO }}
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        // ... Add more name fields up to the max
        public void AddKid(string name)
        {
            switch (numberOfKids)
            {
                case 0: Name1 = name;
                        break;
                case 1: Name2 = name;
                        break;
                // ...
                        
            }
            numberOfKids ++;
        }
    }
    class Kids 
    {
        public int numberOfKids{get;set;}
        public List<string> namesOfKids{get;set;}
    }

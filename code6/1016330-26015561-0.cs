    public class Program
    {
        static void Main(string[] args)
        {
            List<Family> fami = Family.FamilyList();
            //retrieve from list
            Family.DisplaySameSex(fami);
        }
    }
    public class Family
    {
        public string name { set; get; }
        public string sex { set; get; }
        public int age { set; get; }
        public string occupation { set; get; }
        public static void DisplaySameSex(List<Family> sSex)
        {
            foreach (Family f in sSex)
            {
                if (f.sex == "F")
                    Console.WriteLine("Female: " + f.name + "  " + f.sex + "  " + f.age + "  " + f.occupation);
                if (f.age < 30)
                    Console.WriteLine("Child: " + f.name + "  " + f.sex + "  " + f.age + "  " + f.occupation);
            }
        }
        public static List<Family> FamilyList()
        {
            List<Family> fami = new List<Family>();
            ////populate list
            fami.Add(new Family(){name = "Ganpati Prasad", sex = "M",age = 52, occupation = "Under Manager"});
            return fami;
        }
    }

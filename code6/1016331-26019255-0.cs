    namespace ListClassInstance2_74
    {
        class Program
        {
            static void Main(string[] args)
            {
                //call FamilyList to create List
                 List<Family> fami = CreateList.FamilyList();
                Family.DisplaySameSex(fami);
            }
        }
    public class Family
    {
        public string name { set; get; }
        public string sex { set; get; }
        public int age { set; get; }
        public string occupation { set; get; }
        //retrieve info from list
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
    }
    public class CreateList
    {
        public static List<Family> FamilyList()
        {
            List<Family> fami = new List<Family>();
            //populate list
            fami.Add(new Family() { name = "Ganpati Prasad", sex = "M", age = 52, occupation = "Under Manager" });
            fami.Add(new Family() { name = "Manju Devi", sex = "F", age = 49, occupation = "Housewife" });
            fami.Add(new Family() { name = "Anil Kumar", sex = "M", age = 27, occupation = "Entrepreneur" });
            fami.Add(new Family() { name = "Sunil Kumar", sex = "M", age = 25, occupation = "Project Executive" });
            
            return fami;
        }
    }
}

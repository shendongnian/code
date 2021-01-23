    public class Class1 //: IEquatable<Class1>
    {
        public string sText = "";
        public Class1(string sText)
        {
            this.sText = sText;
        }
    
        //public bool Equals(Class1 other)
        //{
        //    return this.sText == other.sText;
        //}
    }
    static void Main(string[] args)
    {
        List<Class1> lstClass1 = new List<Class1>() { new Class1("text1") };
        if (!lstClass1.Contains(new Class1("text1")))
            lstClass1.Add(new Class1("text1"));
        Console.WriteLine(lstClass1.Count);
        Console.ReadKey();
    }

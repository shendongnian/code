     public class test
    {
        static void ContraMethod(Human h)
        {
            h.DisplayLanguage();
        }
        static void ContraForInterfaces(IEnumerable<Human> humans)
        {
            foreach (European euro in humans)
            {
                euro.DisplayLanguage();
            }
        }
        static void Main()
        {
            European euro = new European();
            test.ContraMethod(euro);
            List<European> euroList = new List<European>() { new European(), new European(), new   European() };
            test.ContraForInterfaces(euroList);
        }
    }   

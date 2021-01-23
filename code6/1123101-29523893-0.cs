    public class Company
    {
        public static int counter = 0;
        public Company()
        {
            counter++;
        }
        public string Name {get;set;}
        public Boss Boss { get; set; }
            ~Company()
        {
            counter--;
        }
    }
    public class Boss
    {
        public static int counter = 0;
        public Boss()
        {
            counter++;
        }
        public string Name {get;set;}
        ~Boss()
        {
            counter--;
        }
    }

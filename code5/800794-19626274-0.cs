    class ViewModel
    {
        public string[,] Companies
        {
            get;
            set;
        }
        public List<Example> Values
        {
            get;
            set;
        }
        public ViewModel()
        {
            Companies = new string[2, 2] { { "sjhbfsjh", "jshbvjs" }, {"vsmvs", "nm vmdz" } };
            Values = new List<Example>();
            for (int i = 0; i < 2; i++)
            {
                Example ee = new Example();
                ee.A = Companies[i, 0];
                ee.B = Companies[i, 1];
                Values.Add(ee);
            }
        }
    }
    public class Example
    {
        public string A
        {
            get;
            set;
        }
        public string B
        {
            get;
            set;
        }
    } 

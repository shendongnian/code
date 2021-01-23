    class ViewModel
    {
        public List<Inventory> A
        {
            get;
            set;
        }
        public ViewModel()
        {
            A = new List<Inventory>();
   
            for (int i = 1; i <10; i++)
            {
                Inventory iv = new Inventory();
                iv.Heading = "R" + i ;
                iv.Values = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    iv.Values.Add("Pic");
                }
                A.Add(iv);
            }
        }
    }
    public class Inventory
    {
        public string Heading
        {
            get;
            set;
        }
        public List<string> Values
        {
            get;
            set;
        }
    }

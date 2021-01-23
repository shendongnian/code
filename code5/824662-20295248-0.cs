        class Program
       {
        static void Main(string[] args)
          {
            List<cEspecie> cEspecieList = new List<cEspecie>();
            string[] myEspecieFile = File.ReadAllLines("file.txt");
           
            List<cEspecie> mainList = new List<cEspecie>(); 
            //here you can do the some for the sublist 
            for (int i = 0; i < myEspecieFile.Length; i=i+5)
            {
                
                cEspecie ces = new cEspecie()
                {
                    Name = myEspecieFile[i],
                    LifeTime = int.Parse(myEspecieFile[i + 1]),
                    Movility = int.Parse(myEspecieFile[i + 2]),
                    DeadTo = int.Parse(myEspecieFile[i + 3]),
                    Type = int.Parse(myEspecieFile[i + 4])
                };
                
                mainList.Add(ces);                
            }
            // and then you can  iterate through  your mainList to add sub list  something  like this  
            foreach (var item in mainList)
            {
                item.cSubEspecieList = mainList;  
            }
            
        }
    
    }
    public class cEspecie
    {
        private string name;
        private int lifetime;
        private int movility;
        private int deadto;
        private int type;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public int LifeTime
        {
            get
            {
                return lifetime;
            }
            set
            {
                lifetime = value;
            }
        }
        public int Movility
        {
            get
            {
                return movility;
            }
            set
            {
                movility = value;
            }
        }
        public int DeadTo
        {
            get
            {
                return deadto;
            }
            set
            {
                deadto = value;
            }
        }
        //you need only this property in oreder to create sublist 
        public List<cEspecie> cSubEspecieList
        {
            get;
            set;
        }
    }  

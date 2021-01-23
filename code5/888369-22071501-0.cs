    public Form1()
        {
            InitializeComponent();
    
            Bank ph = new Bank();
            for (int i = 0; i < 4; i++)
            {
                Person p = new Person();
                p.Name = "Jack" + i;
                p.Money = 10;
                m_Persons.Add(p);
    
                ph.Insert(p);
                Console.WriteLine(p.Money);
            }
        }

    class Program
    {
        class Dog
        {            
            public string name { get; set; }
            public bool isAGoodBoy { get; set;}
            public Dog(string name, bool isAGoodBoy)
            {
                this.name = name;
                this.isAGoodBoy = isAGoodBoy;
            }
        }
        static void Main(string[] args)
        {            
            List<Dog> doges = new List<Dog>();
            doges.Add(new Dog("Rufus", true));
            doges.Add(new Dog("Kevin", false)); //chewed furniture
            doges.Add(new Dog("Maximus", true));
            IEnumerable<Dog> goodBoys = doges.Where(doggy => doggy.isAGoodBoy);
            List<Dog> goodBoysList = goodBoys.ToList();
            foreach (var goodBoy in goodBoysList)   //Iterate over NEW list
            {
                goodBoy.isAGoodBoy = false;    //They wouldn't stop barking
            }
            //From original list! You'll see all of these will output 'False'
            Console.WriteLine("Is Rufus good? " + doges[0].isAGoodBoy.ToString());    
            Console.WriteLine("Is Kevin good? " + doges[1].isAGoodBoy.ToString());    
            Console.WriteLine("Is Maximus good? " + doges[2].isAGoodBoy.ToString());    
            Console.ReadLine();
        }
    }

    class GuineaPig
    {
        public string Name;
        public void Well() { Console.WriteLine("I'm " + Name); }
    }
    GuineaPig myPiggie1 = new GuineaPig { Name = "Bubba" };
    GuineaPig myPiggie2 = new GuineaPig { Name = "Lassie" };
    Action myDelegate = null;
    
    myDelegate = new Action( myPiggie1.Well );
    myDelegate(); // -> Bubba
    myDelegate = new Action( myPiggie2.Well );
    myDelegate(); // -> Lassie
    myPiggie1 = myPiggie2 = null;
    myDelegate(); // -> Lassie

    class GuineaPig
    {
        public void Well() { Console.WriteLine("actually"); }
        public void IDontKnow() { Console.WriteLine("what they do"); }
    }
    GuineaPig myPiggie = new GuineaPig();
    myPiggie.Well(); // ok! writes "actually"
    Action myDelegate = null;
    myDelegate = new Action( myPiggie.Well ); // ok!
    myDelegate(); // ok! writes "actually".

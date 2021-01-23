    class GuineaPig
    {
        public static void Squeak() { Console.WriteLine("Ieek!"); }
        public void Well() { Console.WriteLine("actually"); }
        public void IDontKnow() { Console.WriteLine("what they do"); }
    }
    GuineaPig.Squeak(); // says 'ieek'
    Action myDelegate = null;
    myDelegate = new Action( GuineaPig.Squeak );
    myDelegate(); // writes "ieek"
    // GuineaPig.Well(); // cannot do!
    // myDelegate = new Action( GuineaPig.Well ); // cannot do!

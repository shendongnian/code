    using System;
    
    class Program {
        public static event Action Kaboom;
        static void Main(string[] args) {
            Kaboom += new Action(Kaboom);
            var handler = Kaboom;
            if (handler != null) handler();  // kaboom
        }
    }

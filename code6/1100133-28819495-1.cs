    struct Color { 	
        public static readonly Color White = new Color(...); 	
        public static readonly Color Black = new Color(...); 	
        public Color Complement() {...} 
    } 
    class A { 	
        public Color Color;					// Field Color of type Color 	
        void F() { 		
            Color = Color.Black; 			// References Color.Black static member 		              
            Color = Color.Complement();	    // Invokes Complement() on Color field 	
        } 	
        static void G() { 		
        Color c = Color.White;			// References Color.White static member 
        } 
    }

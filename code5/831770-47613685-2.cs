    public struct ChocolateBar {
        int length;
        int girth;
        public static Zero { get; }
    }
    
    OtherClass() {
        ChocolateBar cB = new ChocolateBar(5, 7);
        
        cB = ChocolateBar.Zero();
        Console.Writeline( (cB.length).ToString() ); // Should display 0, not 5
        Console.Writeline( (cB.girth).ToString() ); // Should display 0, not 7
    }

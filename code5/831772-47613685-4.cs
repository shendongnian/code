    public struct ChocolateBar {
        int length;
        int girth;
        public static Zero { get; }
        public ChocolateBar(int length, int girth) {
            this.length = length;
            this.girth = girth;
        }
    }
    
    class OtherClass() {
        ChocolateBar cB = new ChocolateBar(5, 7);
        cB = ChocolateBar.Zero();
        Console.Writeline( (cB.length).ToString() ); // Should display 0, not 5
        Console.Writeline( (cB.girth).ToString() ); // Should display 0, not 7
    }

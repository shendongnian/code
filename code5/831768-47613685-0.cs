    public struct ChocolateBar {
        // In structs, these int values are 0 by default:
        int length;
        int girth;
        // Here's what you do:
        public static Zero { get; }
    
        // Zero gets all the default (static) values of the struct
        // (i.e. 0 for ints)
    }
    
    OtherClass() {
        ChocolateBar cB = new ChocolateBar(5, 7);
        
        // This should set cB to (0, 0):
        cB = ChocolateBar.Zero();
    }

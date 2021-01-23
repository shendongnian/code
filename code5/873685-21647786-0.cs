    class abstract parent
    {
        public enum fruitType{lemon,apple,microsoft};
        public fruitType myType;
        public int ID;
    }
    
    class Lemon : parent
    {
       Lemon(int i){ID=i;myType=fruitType.lemon};
       // various Lemon functions
    }
    class Apple: parent
    {
       Apple(int i){ID=i;myType=fruitType.apple};
       // various Apple functions
    }
    
    then comes the Array:
    class Basket
    {
       public List<parent> basket=new List<parent>();
       void AddToBasket(parent p)
       {
        basket.Add(p);
       }
    
    }
    And in main:
    
    class pgm
    {
       void main()
       {
        Basket bsk=new Basket();
        parent pnt=new parent();
        Lemon  lmn=new Lemon();
        bsk.AddToBasket(lmn);// is this OK?
        
       }
    }

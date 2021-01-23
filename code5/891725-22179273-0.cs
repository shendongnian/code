    class Chameleon 
    { 
        private double length; 
        private string name; 
        private string color; 
 
        //default constructor
        public Chameleon()
        {
          length = 2;
          name = "widget";
          color = "blue";
        }
        //Overloaded Constructor
        public Chameleon( double lengthValue, string nameValue, string colorValue)
        { 
            length = lengthValue; 
            name = nameValue; 
            color = colorValue; 
        } 

    public class Game
    {
        public int ID {get;set;}       
        public string GameName {get;set;}
        public string Developer {get;set;}
        public string Publisher {get;set;}
        public string Genre {get;set;}
        public string Age_Rating {get;set;}
        public decimal Price {get;set;}
        public int Quantity {get;set;}
        public string Description {get;set;}
        public string Platform {get;set;}
    
        public override string ToString()
        {
           return this.GameName + " - " + this.Genre;
        }
    }

    class Collision<type1,type2>:ICollision
    {
        public type1 PropertyOfType1 {get;set;}
        public type2 PropertyOfType2 {get;set;}
        
        object ICollision.PropertyOfType1
        {
            get{return PropertyOfType1;}
        }
        
        object ICollision.PropertyOfType2
        {
            get{return PropertyOfType2;}
        }
    }

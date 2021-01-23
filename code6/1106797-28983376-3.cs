    class CharacterBase 
    {
        public virtual int Level {get;set;}
    }
    
    class Character : CharacterBase 
    {
        public override int Level { get; set; }    //You can give get set implementation here 
    }

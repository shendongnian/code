    class fish()
    {
        Private String _Type;
        Private Int _Age;
        Private String _Species;
        
        Public Type
        {
            get _Type;
            set _Type = Value;
        }
        Public Age
        {
            get _Age;
            set _Age = Value;
        }
        Public Species
        {
            get _Species;
            set _Species = Value;
        }
        public new(string Type, Int Age, String Species)
        {
            this.Type = Type;
            this.Age = Age;
            this.Species = Species;
        }
    }
    
    //this is your new object.
    Fish SunFish = New Fish("small", 9, "Sunfish");

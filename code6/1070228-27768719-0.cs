     public string Choice
        {
            get { return vChoice; }
            set 
            { 
                vChoice = value; 
    
                //Spel opstarten
                this.GeefResult();
            }
        } 

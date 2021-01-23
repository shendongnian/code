    class Event {
        public Texture2D Graphic { get; set; }
        public Vector2 TileLocation { get; set; }
        public List<Condition> Conditions { get; set; }
        public TriggerType Trigger { get; set; }
        public List<Command> Commands { get; set; }
        public int CommandIndex { get; set; }
        public bool Running { get; set; }
        public bool Erased { get; set; }
        public Event() { Erased = false; }
        public void Update(GameTime gameTime){
           if(Erased) return;
           if(Running){ 
              // continue command execution 
           }
           else // check for triggering
              switch(Trigger){ }
        }
        public void Draw()[
           if(Erased) return;
           // drawing code
        }
    }

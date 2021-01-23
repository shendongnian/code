    public class Request
    {
        public string StateString { get; set; }
        [NotMapped] or [Ignore]
        public State CurrentState 
        { 
            get
            {
                return StateFactory.GetState(this.StateString); 
            }
            set
            { 
                this.State = value.GetType().Name; 
            }
        }
    }

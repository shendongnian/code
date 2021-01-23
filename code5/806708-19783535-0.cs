    public class IdCheckingClient : Client
    {
        private int? backingfieldId;
    
        public override int? Id
        {
            get { return backingfieldId; }
            set 
            {
               if(value.HasValue && value.Value < 0)
               {
                   throw new ArgumentException("ID needs to be positive or null");
               }
               backingfieldId = value;
            }  
        }
    } 

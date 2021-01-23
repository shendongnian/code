    public class ApplicationId
        {
            public virtual string UserId { get; set; }
            public virtual string TransactionId { get; set; }
            public virtual Task Task { get; set; }
    
            public override bool Equals(object obj)
            {
                ApplicationId recievedObject = (ApplicationId)obj;
    
                if ((Task.Id == recievedObject.Task.Id) &&
                    (TransactionId == recievedObject.TransactionId) &&
                    (UserId == recievedObject.UserId))
                {
                    return true;
                }
    
                return false;
            }
    
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

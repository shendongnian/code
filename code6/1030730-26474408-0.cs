    public class BaseModel
    {
         // your code, properties, etc.
         ...
        public void SetBaseData(Guid currentUserId)
        {
            if (this.Id < 1)
            {
                this.CreatedDate = _datetime.Now();
                this.CreatedBy = currentUserId;
                this.IsActive = true;
            }
    
            this.UpdatedDate = _datetime.Now();
            this.UpdatedBy = currentUserId;
        }
    }

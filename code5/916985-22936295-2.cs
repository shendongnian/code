    public class User 
    {   
        // the mapped-to-column property 
        protected virtual string PasswordStored
        {
            get ;
            set ;
        }
    
     
        [NotMapped]
        public string Password
        {
            get { return Decrypt(PasswordStored); }
            set { PasswordStored = Encrypt(value); }
        }
    
    
    }

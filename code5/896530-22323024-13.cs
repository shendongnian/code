    public class Product
    {
        public DateTime Expire { get; set; }
        public decimal Price { get; set; }
        public virtual bool IsExpired
        { 
            get { return Expire > DateTime.Now; }
        }
    
        public virtual bool IsValid
        {
            get { return !IsExpired && Price > 0; }
        }
    }

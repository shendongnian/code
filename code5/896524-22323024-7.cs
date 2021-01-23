    public class Product
    {
        public DateTime Expire { get; set; }
        public decimal Price { get; set; }
        public bool IsExpired
        { 
            get { return Expire > return DateTime.Now; }
        }
    
        public bool IsValid
        {
            get { return !IsExpired && Price > 0; }
        }
    }

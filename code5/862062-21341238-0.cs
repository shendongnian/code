    public class Phone
    {
        public double Price {get;set;}
        public string Manufacturer {get;get;}
        public string Model {get;set;}
        public bool HasCord{get;set;}
    
        public override string ToString()
        {
            return string.Format("Phone Manufacturer: {0}\nPhone Model {1}\nHas Cord: {2}\nPhone Price{3}", this.Manufacturer, this.Model, this.HasCord ? "Yes" : "No", this.Price);
        }
    }

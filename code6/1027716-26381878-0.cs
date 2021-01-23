    public class CarModel : IValidatable {
        public string ModelName {get;set;}
        public string ManufacturerName {get;set;}
        public bool IsPropertiesValid() {
            if(ManufacturerName == "Toyota") { 
                if(ModelName == "Prius") return true;
            }
            return false;
        }
    }

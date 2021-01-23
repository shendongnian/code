    public abstract Class AbstractClass
    {
            public virtual int Doors { get; set; }
    
            public virtual int Wheels { get; set; }
    
            public virtual Color VehicleColor { get; set; }
    
            public virtual int TopSpeed { get; set; }
    
            public virtual int HorsePower { get; set; }
    
            public virtual int Cylinders { get; set; }
    
          public string WhatSideDriving
        {
           if (Country == "US") return "Keep Right";
           if (Country == "India") return "Keep Left";
        }
    
    }

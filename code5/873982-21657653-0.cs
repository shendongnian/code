    public class Car : Automobile 
        {
          // public static event Delegates.ObjectInitHandler OnInit; remove this
    
            public string MarketSegment { get; set; }
            public int BootSpace { get; set; } 
    
            public Car(string model, string manufacturer, string yom,ObjectInitHandler OnInit) //add the callback as parameter.
            {
                Model = model ;
                Manufacturer = manufacturer;
                YoM = yom;
                ObjectInitEventArgs eArgs = new ObjectInitEventArgs();
                eArgs.IsResidentObject = true;
                eArgs.ObjectType = this.GetType();
                if (OnInit != null) OnInit(this, eArgs);
            }
    
        }

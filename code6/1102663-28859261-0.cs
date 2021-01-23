    structure Interval{
        public string Name;
        public int Min;
        public int Max;
        
        public Interval(string Name,int Min,int Max){
         this.Name = Name;
         this.Min = Min;
         this.Max = Max;
        }
        public bool IsInsideOfRange(int value){
            if(value >= this.Min && value <= this.Max){
               return true;
            }else{
               return false;
            }
        }
        public overrides ToString(){
          return this.Name;
        }
    
    }
    class IntervalCollection : System.Collections.CollectionBase {
    
       public void Add(string Name,int Min,int Max){
        Interval Item = new Interval(Name,Min,Max);
        this.List.Add(Item);
       }
       public void Add(Interval Item){
        this.List.Add(Item);
       }
       
    
       public string Encode(param int[] values){
           string EcodedText = "";
            foreach(int iValue in values){
               foreach(Interval Item in this){
                    if(Item.IsInsideOfRange(iValue)){
                       EncodedText +=Item.ToString();
                    }
               }
            }
           return EcodedText;
       }
       
    }

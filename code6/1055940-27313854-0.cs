    [FixedLengthRecord()] 
    public class Record
    { 
        [FieldFixedLength(2)] 
        public int CategoryType; 
         
        [FieldFixedLength(3)] 
        [FieldTrim(TrimMode.Right)] 
        public string ActionType; 
     	 
        [FieldFixedLength(7)] 
        [FieldTrim(TrimMode.Right)]
        public string KitNumber; 
     }

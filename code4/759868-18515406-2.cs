    public class MyCustomConverter : ConverterBase 
    { 
        public override object StringToField(string from) 
        { 
            return from.Split('|').Select(s => new ChildClass { Value = s }); 
        } 
     
     
        public override string FieldToString(object fieldValue) 
        { 
            IEnumerable<ChildClass> collection = (IEnumerable<ChildClass>)fieldValue;
            
            return string.Join("|", collection.Select(c => c.Value));
        }          
    } 

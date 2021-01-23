    public MyDataClass SomeTestObject(
         int numbers, string letters, AnotherType anothertype)
    {
         string newString = letters.Substring(0,5);
         int newNumber = numbers + 10;
         AnotherType newType = anothertype.Something();
    
         return new MyDataClass(newString, newNumber, newType);
    }
    //Somewhere else, probably another file
    public class MyDataClass
    {
        public string StringData {get; set;}
        public int NumberData {get; set;}
        public AnotherType ObjectData {get; set;}
        public MyDataClass(string myString, int, myNumber, AnotherType myObject)
        {
            StringData = myString;
            NumberData = myNumber;
            ObjectData = myObject;
        }
    }

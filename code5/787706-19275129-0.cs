    public class SomeClass
    {
        public void myFunction(ref List<string> myList)
        {
        }
    }
    public class SomeOtherClass
    {
        private List<string> list1 { get; set; }
        private List<string> list2 { get; set; }
        private List<string> list3 { get; set; }
        public void DoSomething(int listNumber)
        {
            SomeClass someObject = new SomeClass();
            var parameter = typeof (SomeOtherClass).GetProperty("list" + listNumber).GetValue(this);
            typeof (SomeClass).GetMethod("myFunction").Invoke(someObject, new[] {parameter});
        }
    }

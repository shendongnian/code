    public class MyClass
    {
        public MyClass()
        {
           Urls.OnFull += fullList;
        }
        public MyUrls Urls { get; }
    
        public void fullList()
        {
            //some work with the List
        }
    }
    MyClass mc = new MyClass();
    mc.Urls = new List<string>();
    mc.Urls.Add("www.1.com");
    mc.Urls.Add("www.2.com");
    //now on 3rd added item I want to invoke method fullList from class MyClass
    mc.Urls.Add("www.3.com");

    public enum MyEnum :int
    {
        hi =1,
        Cool =2
    }
    public class test
    {
        public void hello()
        {
            var e = MyEnum.Cool;
            var intValue = (int)e;
            var stringValue = e.ToString();
        }
    }

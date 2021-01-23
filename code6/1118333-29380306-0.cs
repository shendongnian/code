    public class test
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public int p4 { get; set; }
    }
...
    test t1 = new test
    {
        p1 = null,
        p2 = "test1",
        p3 = "test2",
        p4 = 0
    };
    test t2 = new test
    {
        p1 = "test1",
        p2 = "test2",
        p3 = "test3",
        p4 = 0
    };
    test t3 = new test
    {
        p1 = "test1",
        p2 = "tst2",
        p3 = "test3",
        p4 = 0
    };
    
    string filterInput = "test";
    var testStringProperties = typeof(test)
                               .GetProperties()
                               .Where(p => p.PropertyType == typeof(string));
    var a1 = testStringProperties.All(p =>
    {
        string tempValue = (string)p.GetValue(t1);
        return tempValue != null && tempValue.Contains(filterInput);
    });
    var a2 = testStringProperties.All(p =>
    {
        string tempValue = (string)p.GetValue(t2);
        return tempValue != null && tempValue.Contains(filterInput);
    });
    var a3 = testStringProperties.All(p =>
    {
        string tempValue = (string)p.GetValue(t3);
        return tempValue != null && tempValue.Contains(filterInput);
    });
    //a1=false
    //a2=true
    //a3=false

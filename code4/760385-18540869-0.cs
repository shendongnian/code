    page1.xml:
    public class values
        {
            public static var value1 = 123;
            public static var value2 = 234;
            public static var value3 = 345;
           
        }
     page2.xml:
     var localvalue1 = page1.values.value1;
     var localvalue2 = page1.values.value2;
     var localvalue3 = page1.values.value3;

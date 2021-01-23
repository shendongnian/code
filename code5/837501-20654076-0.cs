        class MyClass2
        {
            public int Prop { get; set; }
            public static bool TryParse(string s, MyClass2 result)
            {
                try
                {
                    result.Prop = int.Parse(s);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        
        private static void TestMethod(string str)
        {
            var obj = new MyClass2();
            var rst = MyClass2.TryParse(str, obj);
            Console.WriteLine("bool:{0},int:{1}",rst,obj.Prop);
        }
        [Fact]
        private void TestCase()
        {
            TestMethod("445");
            TestMethod("abc");
        }
        //out put       
    bool:True,int:445       
    bool:False,int:0

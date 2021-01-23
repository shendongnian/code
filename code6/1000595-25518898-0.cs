    class test
        {
            public string var1;
            public string var2;
            public string var3;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<string> testList = new List<string>();
                testList.Add("string1");
                testList.Add("string2");
                testList.Add("string3");
                test testObj = new test();
                var members = testObj.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                for (int i = 0; i < members.Length; i++)
                {
                    members[i].SetValue(testObj, testList[i]);
                }
            }
        }

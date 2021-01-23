    [TestMethod]
            public void MyTest()
            {
                PrivateType privateType = new PrivateType(typeof(MyClass));
                
                var myPrivateDelegateMethod = typeof(MyClass).GetMethod("MyDelegateMethod", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                var dele = myPrivateDelegateMethod.CreateDelegate(typeof(Func<int, int, int>));
                object[] parameterValues =
                            {
                                33,22,dele
                            };
                string result = (string)privateType.InvokeStatic("MyMethodToTest", parameterValues);
                Assert.IsTrue(result == "result is 55");
            }

        private abstract class Base1
        {
        }
        private class Extend1 : Base1
        {
            
        }
            Base1 whatTypeAmI = new Extend1();
            var t = whatTypeAmI.GetType();
            if (t == typeof(Extend1))
                {
                    //do work
                    Console.WriteLine("hello extend1");
                }
            else {
                    Console.WriteLine("I don't know what type I am");
                }
            }

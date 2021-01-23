            [TestMethod]
        public void TestMethod1()
        {
            string[] arrayOfString = new string[500];
            arrayOfString[499] = "Four Ninty Nine";
            Console.WriteLine("Before Modification : {0} " , arrayOfString[499]);
            
            string a = arrayOfString[499];
            ModifyString(out arrayOfString[499]);
            Console.WriteLine("after a : {0}", a);
            Console.WriteLine("after arrayOfString [499]: {0}", arrayOfString[499]);
        }
        private void ModifyString(out string arrayItem)
        {
            arrayItem = "Five Hundred less one";
        }

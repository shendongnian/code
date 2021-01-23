            string inData = comPort1.ReadExisting();
            //Console.WriteLine("inData: " + inData);
            if (inData.Length >= 5)
            {
                string origMsg = inData.Substring(4, 1);
                //Console.WriteLine("origMsg: " + origMsg);
                //string seAnex = inData.Substring(5, 15);           // ArgumentOutOfRangeException
                string seAnex = inData.Substring(5, inData.Length - 5);
                //inData = inData.Substring(5, inData.Length - 8);
                //Console.WriteLine("new inData: " + inData);
                if (seAnex == "some_text_15_ch")
                {
                    //...
                }
                else
                {
                    //...
                }
            }

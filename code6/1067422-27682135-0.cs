            string str1;
 
            string input = "@ztzeré$!]=°°452345é";
            byte[] bs3 = Encoding.ASCII.GetBytes(input);
            
            Encoding encoding = Encoding.UTF8;
            str1 = encoding.GetString(bs3);
            
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            bs3 = unicodeEncoding.GetBytes(str1);
            
            byte[] bs2 = new SHA1Managed().ComputeHash(bs3);
            string str5 = BitConverter.ToString(bs2);
            string str7 = str5.Replace("-", "");
            
            Console.WriteLine("SHA1:" + str7);

            string stringData = "AAAB"; 
            byte[] byteData = Convert.FromBase64String(stringData); 
            StringBuilder sb = new StringBuilder("{");
            BitArray ba = new BitArray(byteData);
            for (int i = 0; i < ba.Length; i++)
            {
                sb.Append(ba[i] ? "1" : "0");    //append 1 if true, 0 if false.
                if (((i + 1) % 8 == 0) && ((i + 1) < ba.Length))  //adds formatting
                    sb.Append("}{");
            }
            sb.Append("}");
            Console.Write("Bytes:" + sb.ToString());
            Console.Read(); //pause

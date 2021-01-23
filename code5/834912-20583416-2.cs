            string str = "Split handles splitting upon string and character delimiters.";
            var strnew = str.Split(' ');
            var strRes = string.Empty;
            int j = 1; 
            for (int i = 0; i < strnew.Length; i=i+2)
            {
                strRes += j.ToString()+": " + @"""" + strnew[i] + " " + strnew[i+1] + @"""" +"\n" ;
                j++; 
            }
            Console.Write(strRes); 
            // print strRes
               

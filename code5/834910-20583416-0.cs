          string str = "Split handles splitting upon string and character delimiters.";
                var strnew = str.Split(' ');
                var strRes = string.Empty; 
                for (int i = 0; i < strnew.Length; i=i+2)
                {
                    strRes += string.Join("\n", strnew[0] + " " + strnew[1]); 
                    
                }
                // print strRes

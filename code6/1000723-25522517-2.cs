            var yourString = "abcdefg";
            var x = '\0';
            for (var i = 0; i < yourString.Length; i++)
            {
                //check whether i+1 index is not out of range
                if (i + 1 != yourString.Length)
                {
                    var test = yourString[i + 1];
                    x = yourString[i];
                    if ((int)x +1 == (int)(test))
                    {
                        //your characters are sequential... 
                        Console.Write("{" + x.ToString() + test.ToString() + "}");
                    }
                }
            }
            Console.Read();

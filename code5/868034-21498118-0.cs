            char[] charArray = x.ToString().ToCharArray();
            int count = 0;
            int total = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '0' )
                {
                    count++;
                }
                else  
                {
                    total = Math.Max(total,count);
                    count = 0;
                }
            }
            return total;
        }

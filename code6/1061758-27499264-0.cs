            public static string TimestampToString(this System.Data.Linq.Binary binary)
            {
                byte[] binarybytes = binary.ToArray();
                string result = "";
                foreach (byte b in binarybytes)
               {
                    result += b.ToString() + "|";
                }
                result = result.Substring(0, result.Length - 1);
                return result;
           }
     
            public static System.Data.Linq.Binary StringToTimestamp(this string s)
            {
                string[] arr = s.Split('|');
                byte[] result = new byte[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    result[i] = Convert.ToByte(arr[i]);
                }
                return result;
            }

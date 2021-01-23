            if (string.IsNullOrWhiteSpace(emoji))
                return emoji;
            byte[] bytes = Encoding.UTF8.GetBytes(emoji);
            string firstItem = Convert.ToString(bytes[0], 2);  
            
            int iv;
            if (bytes.Length == 1)
            {
                iv = Convert.ToInt32(firstItem, 2);
            }
            else
            {
                StringBuilder sbBinary = new StringBuilder();
                sbBinary.Append(firstItem.Substring(bytes.Length + 1).TrimStart('0'));
                for (int i = 1; i < bytes.Length; i++)
                {
                    string item = Convert.ToString(bytes[i], 2);
                    item = item.Substring(2);
                    sbBinary.Append(item);
                }
                iv = Convert.ToInt32(sbBinary.ToString(), 2);
            }
            return Convert.ToString(iv, 16).PadLeft(4, '0');
        }

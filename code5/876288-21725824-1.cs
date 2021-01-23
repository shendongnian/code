      StringBuilder sb = new StringBuilder();  
      for (int i = 0; i < hexStr.Length; i += 2)
        {
            string hs = hexStr.Substring(i, 2);
            sb.Append(Convert.ToByte(hs, 16));
        }

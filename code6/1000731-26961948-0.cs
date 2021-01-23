    using (ODC.OracleDataReader rdr = cmd.ExecuteReader())
    {
       if (rdr.Read())
       {
           var clob = rdr.GetOracleClob(0);
           // Can not simply use clob.Value - throws ORA-03113
           // Need to read input in chunks
           long length = clob.Length;
           List<byte> bytes = new List<byte>();
           int offset = 0;
           while (offset < length)
           {
              int readLength = (int)Math.Min(1024, length - offset);
              byte[] tmp = new byte[readLength];
              int readBytes = clob.Read(tmp, 0, readLength);
              offset += readLength;
              bytes.AddRange(tmp);
           }
        string xml = System.Text.Encoding.Unicode.GetString(bytes.ToArray()); 
        return DecodeXmlString(xml);
    }
    else
        return null;
    }

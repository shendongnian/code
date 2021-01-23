    public static byte[] ToByteArray<T>(this T o)
    {
         if (o == null)
              return null;
         using (MemoryStream ms = new MemoryStream())
         {
             ProtoBuf.Serializer.Serialize(ms, o);
             return ms.ToArray();
         }
    }

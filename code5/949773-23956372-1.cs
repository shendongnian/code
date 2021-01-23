    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.IO;
    using ProtoBuf;
    public static class ProtoBuffHelper
    {
        public static byte[] Serialize<T>(T Objeto)
        {
            MemoryStream ms = new MemoryStream();
            Serializer.Serialize<T>(ms, Objeto);
            byte[] data = ms.ToArray();
            ms.Dispose();
            return data;
        
        }
        public static T Deserialize<T>(byte[] Datos)
        {
            MemoryStream ms = new MemoryStream(Datos);
            T inst = Serializer.Deserialize<T>(ms);
            ms.Dispose();
            return inst;
        
        }
    }

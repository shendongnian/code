    Base base = new Base(){...};
    Derived derived = XmlClone.CloneToDerived<Base, Derived>(base);
    public static class XmlClone
    {
        public static D CloneToDerived<T, D>(T pattern)
            where T : class
        {
            using (var ms = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(ms))
                {
                    Type typePattern = typeof(T);
                    Type typeTarget = typeof(D);
        
                    XmlSerializer xmlSerializerIn = new XmlSerializer(typePattern);
                    xmlSerializerIn.Serialize(writer, pattern);
                    ms.Position = 0;
                    XmlSerializer xmlSerializerOut = new XmlSerializer(typeTarget, new XmlRootAttribute(typePattern.Name));
                    D copy = (D)xmlSerializerOut.Deserialize(ms);                    
                    return copy;
                }
            }
        }
    }

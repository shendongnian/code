    invoice.UBLExtensions = new List<object>();
    invoice.UBLExtensions.Add(addInfo);
    Type typeToSerialize = typeof(InvoiceType);
    Type[] extraTypes = null;
    if (invoice.UBLExtensions != null)
    { extraTypes = invoice.UBLExtensions.Select((e) => e.GetType()).ToArray(); }
    // Now the serializer knows all additional types
    XmlSerializer xs = new XmlSerializer(typeToSerialize, extraTypes);

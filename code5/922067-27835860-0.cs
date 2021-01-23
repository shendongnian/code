    MEF_ComponenentList.Select(item => item.GetType());
    public static void SerializeSomething<T>(T objToSave, string fileToSaveTo, IEnumerable<Type> KnownTypes = null)
        {
            var ser = new  System.Runtime.Serialization.DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings { Indent = true };
            System.IO.File.Delete(fileToSaveTo);
            if (KnownTypes != null)
            {
                var sum = ser.KnownTypes.Concat(KnownTypes);
                ser = new  System.Runtime.Serialization.DataContractSerializer(typeof(T), sum);
            }
            using (var writer = XmlWriter.Create(fileToSaveTo, settings))
            {
                ser.WriteObject(writer, objToSave);
            }
        }

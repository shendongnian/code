    private String SerializeToXmlString<T>(T objectToSerialise)
            {
                var serializeHelper = new SerializeHelperImp();
                return serializeHelper.SerializeToXmlString<T>(objectToSerialise, new UTF8Encoding());
            }

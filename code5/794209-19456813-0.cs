        var codes = new Codes { CodeCollection = codeCollection };
        XmlSerializer _serializer = new XmlSerializer(typeof(Codes));
        using (StreamWriter _writer = new StreamWriter(@"LocalCodes.xml"))
        {
            _serializer.Serialize(_writer, codes);
        }

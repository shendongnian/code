            string xml;
            using (var textWriter = new StringWriter())
            using (var writer = new RootlessDataSetXmlWriter(textWriter, ds.DataSetName))
            {
                ds.WriteXml(writer);
                xml = textWriter.ToString();
            }

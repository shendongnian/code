            using (var writer = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(writer))
                {
                    xslt.Transform(beforeTransform.CreateNavigator(), xmlWriter);
                }
                var tempDoc = new XmlDocument();
                tempDoc.LoadXml(writer.ToString());
                afterTransfrom = tempDoc.DocumentElement;
            }

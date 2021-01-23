            public static string Serialize(object obj)
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                using (StringWriter textWriter = new StringWriter())
                {
                    xs.Serialize(textWriter, obj);
                    return textWriter.ToString();
                }
            }

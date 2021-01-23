            Elements elements = new Elements
            {
                listObjet = new List<Element>
                {
                    new Element
                    {
                        id = 1,
                        pos_x = 10,
                        pos_y = 20,
                        rot = 8
                    }
                }
            };
            var serializer = new XmlSerializer(typeof(Elements));
            string output;
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, elements);
                output = writer.ToString();
            }
            // Todo: check output format

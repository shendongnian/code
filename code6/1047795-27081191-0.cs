        private void SerializeObject(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OrderedItem));
            OrderedItem i = new OrderedItem();
            i.ItemName = "Widget";
            i.Description = "Regular Widget";
            i.Quantity = 10;
            i.UnitPrice = (decimal)2.30;
            i.Calculate();
            Console.WriteLine(string.Format("Writing \"{0}\" With XmlTextWriter", filename));
            SerializeObject(i, filename);
        }
        public static void SerializeObject<T>(T obj, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    ", Encoding = Encoding.Unicode };
                using (var writer = XmlWriter.Create(fs, settings))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

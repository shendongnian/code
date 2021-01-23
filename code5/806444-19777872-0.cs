    //Method for serialization. Just In case if you went wrong some where
        public static string SerializeElement(object transactiondetails)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(transactions));
                    StringWriter sww = new StringWriter();
                    XmlWriter writer1 = XmlWriter.Create(sww);
                    ser.Serialize(writer1, transactiondetails);
                    writer1.Close();
                    return sww.ToString();
                }

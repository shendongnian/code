        static string GenerateXmlFromTable(string tableName, bool useAttribute)
        {
            XmlDocument document = new XmlDocument();
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", null, null);
            document.AppendChild(declaration);
            XmlElement rootElement = document.CreateElement("Command");
            document.AppendChild(rootElement);
            using (SQLiteConnection connection = new SQLiteConnection("Data source=SqlLite.db"))
            {
                connection.Open();
                string query = string.Format("Select * from {0}", tableName);
                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            XmlElement recordElement = document.CreateElement(tableName);
                            rootElement.AppendChild(recordElement);
                            for(int index = 0; index < reader.FieldCount; index++)
                            {
                                if (useAttribute)
                                {
                                    recordElement.SetAttribute(reader.GetName(index), reader.GetValue(index).ToString());
                                }
                                else
                                {
                                    XmlElement valueElement = document.CreateElement(reader.GetName(index));
                                    valueElement.InnerText = reader.GetValue(index).ToString();
                                    recordElement.AppendChild(valueElement);
                                }
                            }
                        }
                    }
                }
            }
            using(StringWriter stringWriter = new StringWriter(new StringBuilder()))
            using(XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter))
            {
                xmlWriter.Formatting = Formatting.Indented;
                document.Save(xmlWriter);
                return stringWriter.ToString();
            }
        }

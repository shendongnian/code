            private string Serialize(object value)
            {
                System.IFormatProvider provider = System.Globalization.CultureInfo.CurrentCulture;
                StringBuilder builder = new StringBuilder();
                string serializedString = string.Empty;
                try
                {
                    XmlSerializer xs = new XmlSerializer(value.GetType());
                    XmlWriter xmlTextWriter = XmlTextWriter.Create(builder);
                    xs.Serialize(xmlTextWriter, value);
                    serializedString = builder.ToString();
                    xmlTextWriter.Close();
                }
                catch (Exception ex)
                {
                    serializedString = "Serialization exception  : " + ex.Message + ex.StackTrace;
                }
                return serializedString;
            }

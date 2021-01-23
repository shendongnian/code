     using (SqlConnection conn = new SqlConnection(con))
        {
            XDocument results = new XDocument(
           new XElement("results"));
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MyStoredProc";
                conn.Open();
                var count = 0;
                using (XmlReader reader = cmd.ExecuteXmlReader())
                {
                    while (reader.Read())
                    {
                        results.Root.Add(XElement.Parse(reader.ReadOuterXml()));
                        count += 1;
                    }
                }
                return results.ToString();
            }
        }

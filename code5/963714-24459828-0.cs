        private static SqlDataReader GetData(SqlConnection sqlConn, int subscriberID, DateTime fromDate, DateTime toDate)
        {
            SqlDataReader rdr;
            using (System.Data.SqlClient.SqlCommand cmd = new SqlCommand("GetData", sqlConn)) 
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubscriberId", subscriberID);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                rdr = cmd.ExecuteReader();  
            }
            return (rdr);
        }
        private static string WriteXml(SqlConnection sqlConn)
        {
            string xmlOutput = "";
            System.Data.SqlClient.SqlDataReader rdrDealers = GetDealers(sqlConn);
            {
                while (rdrDealers.Read())
                {
                    using (SqlDataReader rdrCalls = GetData(...)
                    {
                        if (rdrCalls.HasRows)
                        {
                            XmlWriterSettings wSettings = new XmlWriterSettings();
                            wSettings.Indent = true;
                            MemoryStream ms = new MemoryStream();
                            XmlWriter xw = XmlWriter.Create(ms, wSettings);
                            xw.WriteStartDocument();
                            xw.WriteStartElement("program");
                            xw.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                            xw.WriteAttributeString("xsi", "noNamespaceSchemaLocation", null, "program.xsd");
                            {
                                string CContractId = Convert.ToString(rdrDealers.GetInt32(1));
                                string clientName = rdrDealers.GetString(2);
                                xw.WriteStartElement("Customer");
                                xw.WriteStartElement("CContractId");
                                xw.WriteString(CContractId);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ClientName");
                                xw.WriteString(clientName);
                                xw.WriteEndElement();
                                xw.WriteStartElement("SubscriberId");
                                xw.WriteString(Convert.ToString(subscriberID));
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.WriteStartElement("CreatedOn");
                                xw.WriteString(DateTime.UtcNow.ToString("o"));
                                xw.WriteEndElement();
                                while (rdrCalls.Read())
                                {
                                    string messageID = Convert.ToString(rdrCalls[0] as int?);  // rdrCalls[0] as string;
                                    string deliveryChannelID = Convert.ToString(rdrCalls[1] as int?); //Convert.ToString(rdrCalls.GetInt32(1));
                                    string sentTms = (rdrCalls[2] as DateTime? ?? default(DateTime)).ToUniversalTime().ToString("o");
                                    string campaignName = rdrCalls[3] as string;
                                    string prospectID = rdrCalls[4] as string;
                                    string myCampaignID = rdrCalls[5] as string;
                                    xw.WriteStartElement("Message");
                                    xw.WriteStartElement("MessageId");
                                    xw.WriteAttributeString("DeliveryChannel", Convert.ToString(deliveryChannelID));
                                    xw.WriteString(messageID);
                                    xw.WriteEndElement();
                                    xw.WriteStartElement("Prospect");
                                    xw.WriteStartElement("Id");
                                    xw.WriteString(prospectID);
                                    xw.WriteEndElement();
                                    xw.WriteEndElement();
                                    xw.WriteStartElement("SentTms");
                                    xw.WriteString(sentTms);
                                    xw.WriteEndElement();
                                    xw.WriteStartElement("CampaignName");
                                    xw.WriteString(campaignName);
                                    xw.WriteEndElement();
                                    xw.WriteStartElement("myCampaignId");
                                    xw.WriteString(myCampaignID);
                                    xw.WriteEndElement();
                                    xw.WriteEndElement();
                                }
                            }
                            xw.WriteEndDocument();
                            xw.Flush();
                            Byte[] buffer = new Byte[ms.Length];
                            buffer = ms.ToArray();
                            xmlOutput = System.Text.Encoding.UTF8.GetString(buffer);
                            string filePath = ...
                            File.WriteAllText(filePath, xmlOutput);
                            using (WebClient client = new WebClient())
                            {
                                client.UploadFile(url, filePath);
                            }
                        }
                    }
                }
            }
            return xmlOutput;
        }

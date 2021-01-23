    private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\QRXS\download\14000000000000251943.xml");
            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList rootNodes = xelRoot.SelectNodes("/queryConfirmation");
            XmlNodeList submitterNodes = xelRoot.SelectNodes("/queryConfirmation/submitter"); 
            XmlNodeList certNode = xelRoot.SelectNodes("/queryConfirmation/certification");
            XmlNodeList certPhoneNode = xelRoot.SelectNodes("/queryConfirmation/certification/phone");
            XmlNodeList batchNodeList = xelRoot.SelectNodes("/queryConfirmation/batchStatus");
            XmlNodeList bsErrorList = xelRoot.SelectNodes("/queryConfirmation/batchStatus/error");
            foreach (XmlNode xndNode in submitterNodes)
            {
                entityDBID = xndNode["entityDBID"].InnerText;
                vendorID = xndNode["vendorID"].InnerText;
                foreach (XmlNode submisFilenameNode in rootNodes)
                {
                    submissionFilename = submisFilenameNode["submissionFilename"].InnerText;
                    
                }
                foreach (XmlNode cfn in certNode)
                {
                    name = cfn["name"].InnerText;
                    title = cfn["title"].InnerText;
                    certificationDate = cfn["date"].InnerText;
                }
                foreach (XmlNode cfnp in certPhoneNode)
                {
                    phoneNumber = cfnp["number"].InnerText;
                    phoneExtension = cfnp["extension"].InnerText;
                }
                foreach (XmlNode bsNode in batchNodeList)
                {
                    dcn = bsNode["dcn"].InnerText;
                    processDate = bsNode["processDate"].InnerText;
                    successfullyProcessed = bsNode["successfullyProcessed"].InnerText;
                }
                foreach (XmlNode bsError in bsErrorList)
                {
                    code = bsError["code"].InnerText;
                    message = bsError["message"].InnerText;
                }
                try
                {
                    DA.InsertCommand = new SqlCommand("INSERT INTO response VALUES (@entityDBID, @vendorID, @submissionFilename, @fullName, @title, @number, @extension, @certificationDate, @dcn, @processDate, @successfullyProcessed, @code, @message);", DRDB);
                    DA.InsertCommand.Parameters.AddWithValue("@entityDBID", SqlDbType.NVarChar).Value = entityDBID;
                    DA.InsertCommand.Parameters.AddWithValue("@vendorID", SqlDbType.NVarChar).Value = vendorID;
                    DA.InsertCommand.Parameters.AddWithValue("@submissionFilename", SqlDbType.NVarChar).Value = submissionFilename;
                    DA.InsertCommand.Parameters.AddWithValue("@fullName", SqlDbType.NVarChar).Value = name;
                    DA.InsertCommand.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = title;
                    DA.InsertCommand.Parameters.AddWithValue("@number", SqlDbType.NVarChar).Value = phoneNumber;
                    DA.InsertCommand.Parameters.AddWithValue("@extension", SqlDbType.NVarChar).Value = phoneExtension;
                    DA.InsertCommand.Parameters.AddWithValue("@certificationDate", SqlDbType.NVarChar).Value = certificationDate;
                    DA.InsertCommand.Parameters.AddWithValue("@dcn", SqlDbType.NVarChar).Value = dcn;
                    DA.InsertCommand.Parameters.AddWithValue("@processDate", SqlDbType.NVarChar).Value = processDate;
                    DA.InsertCommand.Parameters.AddWithValue("@successfullyProcessed", SqlDbType.NVarChar).Value = successfullyProcessed;
                    DA.InsertCommand.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    DA.InsertCommand.Parameters.AddWithValue("@message", SqlDbType.NVarChar).Value = message;
                    DRDB.Open();
                    DA.InsertCommand.ExecuteNonQuery();
                    DRDB.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

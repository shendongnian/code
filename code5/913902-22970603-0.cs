    private void readAndInsertXmlFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "XML|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
              {
                using (XmlTextReader reader = new XmlTextReader(openFile.FileName))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "entityDBID":
                                    
                                   
                                        qc.submitter.entityDBID = reader.ReadString();
                                    
                                    
                                    break;
                                case "vendorID":
                                    
                                        qc.submitter.vendorID = reader.ReadString();
                                    
                                    
                                    break;
                                case "submissionFilename":
                                    
                                        qc.submissionFilename.SubmissionFilename = reader.ReadString();
                                    
                                    
                                    break;
                                case "name":
                                   
                                        qc.certification.name = reader.ReadString();
                                    
                                    
                                    break;
                                case "title":
                                    
                                        qc.certification.title = reader.ReadString();
                                    
                                    
                                    break;
                                case "number":
                                   
                                        qc.certification.phone.number = reader.ReadString();
                                   
                                    
                                    break;
                                case "extension":
                                  
                                        qc.certification.phone.extension = reader.ReadString();
                                        
                                    
                                    break;
                                case "date":
                                    
                                        qc.certification.date = reader.ReadString();
                                    
                                    
                                    break;
                                case "dcn":
                                    
                                        qc.batchStatus.dcn = reader.ReadString();
                                    
                                    
                                    break;
                                case "processDate":
                                    
                                        qc.batchStatus.processDate = reader.ReadString();
                                    
                                    
                                    break;
                                case "successfullyProcessed":
                                   
                                        qc.batchStatus.successfullyProcessed = reader.ReadString();
                                    
                                    
                                    break;
                                case "code":
                                    
                                        qc.error.Code = reader.ReadString();
                                    
                                    
                                    break;
                                case "message":
                                  
                                        qc.error.Message = reader.ReadString();
                                    
                                    
                                    break;
                            }
                        }
                    }
                    DA.InsertCommand = new SqlCommand("INSERT INTO response VALUES (@entityDBID, @vendorID, @submissionFilename, @fullName, @title, @number, @extension, @certificationDate, @dcn, @processDate, @successfullyProcessed, @code, @message);", DRDB);
                    if (qc.submitter.entityDBID == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@entityDBID", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@entityDBID", SqlDbType.NVarChar).Value = qc.submitter.entityDBID;
                    }
                    if (qc.submitter.vendorID == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@vendorID", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@vendorID", SqlDbType.NVarChar).Value = qc.submitter.vendorID;
                    }
                    if (qc.submissionFilename.SubmissionFilename == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@submissionFilename", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@submissionFilename", SqlDbType.NVarChar).Value = qc.submissionFilename.SubmissionFilename;
                    }
                    if (qc.certification.name == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@fullName", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@fullName", SqlDbType.NVarChar).Value = qc.certification.name;
                    }
                    if (qc.certification.title == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = qc.certification.title;
                    }
                    if (qc.certification.phone.number == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@number", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@number", SqlDbType.NVarChar).Value = qc.certification.phone.number;
                    }
                    if (qc.certification.phone.extension == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@extension", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@extension", SqlDbType.NVarChar).Value = qc.certification.phone.extension;
                    }
                    if (qc.certification.date == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@certificationDate", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@certificationDate", SqlDbType.NVarChar).Value = qc.certification.date;
                    }
                    if (qc.batchStatus.dcn == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@dcn", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@dcn", SqlDbType.NVarChar).Value = qc.batchStatus.dcn;
                    }
                    if (qc.batchStatus.processDate == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@processDate", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@processDate", SqlDbType.NVarChar).Value = qc.batchStatus.processDate;
                    }
                    if (qc.batchStatus.successfullyProcessed == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@successfullyProcessed", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@successfullyProcessed", SqlDbType.NVarChar).Value = qc.batchStatus.successfullyProcessed;
                    }
                    if (qc.error.Code == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = qc.error.Code;
                    }
                    if (qc.error.Message == null)
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@message", SqlDbType.NVarChar).Value = "NULL";
                    }
                    else
                    {
                        DA.InsertCommand.Parameters.AddWithValue("@message", SqlDbType.NVarChar).Value = qc.error.Message;
                    }
                    DRDB.Open();
                    DA.InsertCommand.ExecuteNonQuery();
                    DRDB.Close();
                }
            }
        }

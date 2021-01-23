           System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
           settings.IgnoreWhitespace = true;
                //read the .trdx file contents
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(path_to your_trdx_file, settings))
                {
                    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer =
                        new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                    //deserialize the .trdx report XML contents
                    Telerik.Reporting.Report report = (Telerik.Reporting.Report)
                        xmlSerializer.Deserialize(xmlReader);
                    string mimType = string.Empty;
                    string extension = string.Empty;
                    Encoding encoding = null;
                    // call Render() and retrieve raw array of bytes
                    // write the pdf file
                    byte[] buffer = Telerik.Reporting.Processing.ReportProcessor.Render(
                    "PDF", report, null, out mimType, out extension, out encoding);
                    // create a new file on disk and write the byte array to the file
                    FileStream fs = new FileStream(Path_you_need_to_save_the_pdf_file, FileMode.Create);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                    fs.Close();
                }

    byte[] bytes = memoryStream.ToArray();
                //Save pdf in the temporary location.
                System.IO.File.WriteAllBytes(Server.MapPath("~/TempReports/") + lbReports.Text + "_JEA.pdf", bytes);
                /*This is a page counter - it stamps the number of pages in the document. 
                 It will read dynamically the 'document' that was just closed above [document.Close();] from the location, 
                 then in memory will write the new content plus the one from [byte[] bytes = memoryStream.ToArray();] 
                 Solution has been applied from: https://www.aspsnippets.com/Articles/iTextSharp-Add-Page-numbers-to-existing-PDF-using-C-and-VBNet.aspx
                 */
                try
                {
                    File.ReadAllBytes(Server.MapPath("~/TempReports/") + lbReports.Text + "_JEA.pdf");
                    iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        PdfReader reader = new PdfReader(bytes);
                        using (PdfStamper stamper = new PdfStamper(reader, stream))
                        {
                            int pages = reader.NumberOfPages;
                            for (int i = 1; i <= pages; i++)
                            {
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                 @Element.ALIGN_LEFT, new Phrase(lbReports.Text + " - Hydrants - JEA", blackFont), 63f, 24f, 0);
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_CENTER, new Phrase("Page " + i.ToString() + " of " + pages, blackFont), 300f, 24f, 0);
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_RIGHT, new Phrase("" + DateTime.Now, blackFont), 549f, 24f, 0);
                            }
                            txConnection.Text = "This report contains " + pages + " page(s)";
                        }
                        bytes = stream.ToArray();
                    }//End of page counter
                    /*System.IO.File.WriteAllBytes will write all bytes to file again*/
                    System.IO.File.WriteAllBytes(Server.MapPath("~/TempReports/") + lbReports.Text + "_JEA.pdf", bytes);
                    // Temporary path that is used to display the pdf in the embed.
                    System.IO.File.WriteAllBytes(Server.MapPath("~/TempReports/ReportsEmbed/") + lbReports.Text + "_JEA.pdf", bytes);
                    /*this is what sends the PDF to the embed viewer object
                     The ltEmbed is what receives the plugin to dispplay the file*/
                    string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"698px\" height=\"450px\">";
                    embed += "If you are unable to view file, you can download it from <a href = \"{0}\">here</a>";
                    embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view it.";
                    embed += "</object>";
                    ltEmbed.Text = string.Format(embed, ("http://localhost:65423/TempReports/ReportsEmbed/") + lbReports.Text + "_JEA.pdf");
                    memoryStream.Close();
                    this.Context.ApplicationInstance.CompleteRequest();
                }
                catch (DocumentException exe)
                {
                    txConnection.Text = "There has been an error generating the file. Please try again. Error: " + exe;
                }

    public ActionResult ExportToCsv()
    {
        string Path = @"C:\\5Newwithdate.xls";
        using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + Path + "';Extended Properties=" + (char)34 + "Excel 8.0;IMEX=1;" + (char)34 + ""))
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con))
            {
                con.Close();
                System.Data.DataTable data = new System.Data.DataTable();
                da.Fill(data);
                SQLDBBillingProvider sql = new SQLDBBillingProvider();
                List<TopPlayed> daa = new List<TopPlayed>();
    
                // Create a memory stream and a TextWriter that uses it for its output
                using (var sw = new StreamWriter(new MemoryStream()))
                {
                    // Write the header row
                    sw.WriteLine("\"ID\", \"Track\", \"Artist\", \"Plays\"");
                    // Write the data here..
                    foreach (DataRow p in data.Rows)
                    {
                        TopPlayed top = new TopPlayed()
                        {
                            TrackID = p.Field<double>("ID").ToString(),
                            TrackName = p.Field<string>("Track Name"),
                            ArtistName = p.Field<string>("Artist Name"),
                            Times = p.Field<double>("NoOfPlays").ToString()
                        };
                        // Write a single CSV line
                        sw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\"", top.TrackID, top.TrackName, top.ArtistName, top.Times);
                    }
                    // Now return the stream to the client/browser    
                    HttpContext.Response.ClearContent();
                    HttpContext.Response.AddHeader("content-disposition", "attachment; filename=TopTracks.csv");
                    HttpContext.Response.AddHeader("Expires", "0");
                    // Flush the stream and reset the file cursor to the start
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    // return the stream with Mime type
                    return new FileStreamResult(sw.BaseStream, "text/csv");
                }
            }
        }
    }

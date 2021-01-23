    string MyConString = "SERVER=10.0.0.3;" + "DATABASE=myvideos75;" + "UID=xbmc;" + "PASSWORD=xbmc;";
    string SQLSelect = "SELECT tvshow.idShow as 'idShow',tvshow.c00 as 'ShowName',episode.c12 as 'Season',XBMCPathReFact(episode.c18) as 'Path' FROM myvideos75.episode join tvshow on tvshow.idShow = episode.idShow group by episode .idShow,episode.c12";
            try
            {if (File.Exists(_XMLFile))
                {File.Delete(_XMLFile);}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
            MySqlConnection connection = new MySqlConnection(MyConString);
            
            try
            {
                MySqlCommand _MySqlSelect = new MySqlCommand(SQLSelect, connection);
                DataSet _DataSet1 = new DataSet("XBMC");
                MySqlDataAdapter _MySqlDataAdapter1 = new MySqlDataAdapter(_MySqlSelect);
                _MySqlDataAdapter1.Fill(_DataSet1,"Show");
                XDocument xdoc;
                XElement root;
                XElement tvshow;
                XElement TvShowElement;
                xdoc = new XDocument(new XElement("XBMC"));
                root = xdoc.XPathSelectElement("//XBMC");   
                // loop start fills stuff in 
       
                foreach (DataRow row in _DataSet1.Tables[0].Rows)
                {
                    // Test if the show exists if not create it and add all the Element
                    var ShowIDTest = xdoc.Element("XBMC").Elements("Show").Where(x => x.Element("idShow").Value.Equals(row["idShow"].ToString())).ToList();
                    if (ShowIDTest.Count < 1)
                    {
                        TvShowElement = new XElement("Show",
                                        new XElement("idShow", row["idShow"].ToString()),
                                        new XElement("ShowName", row["ShowName"].ToString()),
                                        new XElement("Seasons",
                                        new XElement("Season",
                                        new XElement("Number", row["Season"].ToString()),
                                        new XElement("Path", row["Path"].ToString()))));
                        root.Add(TvShowElement);
                    }
                    // The Show Exists , go to the show
                    else
                    {
                        string tvshowpath = "/XBMC/Show[idShow =\"" + row["idShow"].ToString() + "\"]";
                        tvshow = xdoc.XPathSelectElement(tvshowpath);
                        // Check if the show already has any season if not create it 
                        bool SeasonsTest = tvshow.Descendants("Seasons").Any();
                        if (!SeasonsTest)
                        {
                            TvShowElement = new XElement("Seasons",
                                            new XElement("Season",
                                            new XElement("Number", row["Season"].ToString()),
                                            new XElement("Path", row["Path"].ToString())));
                            tvshow.Add(TvShowElement);
                        }
                        // the show already has any season element so append the additional seasons
                        else
                        {
                            string tvshowseasonspath = "/XBMC/Show[idShow =\"" + row["idShow"].ToString() + "\"]/Seasons";
                            tvshow = xdoc.XPathSelectElement(tvshowseasonspath);
                            TvShowElement = new XElement("Season",
                                            new XElement("Number", row["Season"].ToString()),
                                            new XElement("Path", row["Path"].ToString()));
                            tvshow.Add(TvShowElement);
                        }
                      }
                   }
                // Save the XML File   
                xdoc.Save(_XMLFile);
                MessageBox.Show("done");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }

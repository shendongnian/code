                XmlDocument doc = new XmlDocument();
                doc.Load(movieListXML);
                XmlNode node = doc.SelectSingleNode("/MovieData");
                foreach (XmlNode movie in node.SelectNodes("Movie"))
                {
                    if (movie != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)movieListDataViewBox.Rows[0].Clone();
                        row.Cells[0].Value = movie["Name"].InnerText;
                        row.Cells[1].Value = movie["Rating"].InnerText;
                        row.Cells[2].Value = movie["Disk"].InnerText;
                        row.Cells[3].Value = movie["LengthHr"].InnerText + " Hr. " + movie["LengthMin"].InnerText + " Min.";
                        var cb = row.Cells[4] as DataGridViewComboBoxCell; // this is for a combo box item in datagrid
                        cb.Items.Clear(); // this is for a combo box item in datagrid
                        XmlNodeList nodeList = movie.ChildNodes;
                        string str = "";
                        foreach(XmlNode nl in nodeList)
                        {
                            if ((nl.Name == "Type"))
                            {
                                cb.Items.Add(nl.InnerText); // this is for a combo box 
                            }
                        }
                        row.Cells[4].Value = str;
                        row.Cells[5].Value = movie["SeriesType"].InnerText;
                        row.Cells[6].Value = movie["Location"].InnerText;
                        row.Cells[7].Value = movie["Owner"].InnerText;
                        row.Cells[8].Value = movie["Date"].InnerText;
                        row.Cells[9].Value = movie["Time"].InnerText;
                        row.Cells[10].Value = "Pictures";
                        movieListDataViewBox.Rows.Add(row);
                    }
                }

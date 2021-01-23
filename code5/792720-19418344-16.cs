      XmlDocument xDoc = new XmlDocument();
            xDoc.Load("E:\\test.xml");
            XmlNodeList xE = xDoc.SelectNodes("//MovieData/Movie/LengthMin");
            Dictionary<string, string> dicMovieData = null;
            if (xE != null)
            {
                for (int iVal = 0; iVal < xE.Count; iVal++)
                {
                    if (xE[iVal] is XmlNode)
                    {
                        XElement xElement = XElement.Parse("<Temp>" + xE[iVal].ParentNode.InnerXml + "</Temp>");
                        if (xElement != null)
                        {
                            dicMovieData = new Dictionary<string, string>();
                            foreach (XElement xMovieData in xElement.Descendants())
                            {
                                if (!dicMovieData.ContainsKey(xMovieData.Name.LocalName))
                                    dicMovieData.Add(xMovieData.Name.LocalName, xMovieData.Value);
                            }
                            string sName = "Death Race";
                            string sDate = "10/13/2013";
                            string sTime = "10:44:23 PM";
                            string sLenghHR = "1";
                            string sLengthMin = "51";
                            if (dicMovieData != null && dicMovieData.Count > 0)
                            {
                                if (string.Compare(dicMovieData["Name"], sName, true) == 0
                                    && string.Compare(dicMovieData["Date"], sDate, true) == 0
                                    && string.Compare(dicMovieData["Time"], sTime, true) == 0
                                    && string.Compare(dicMovieData["LengthHr"], sLenghHR, true) == 0
                                    && string.Compare(dicMovieData["LengthMin"], sLengthMin, true) == 0)
                                {
                                    XmlElement xNewChild = xDoc.CreateElement("Image");
                                    xNewChild.InnerText = "string";
                                    XmlNode commonParent = xE[iVal].ParentNode;
                                    commonParent.InsertAfter(xNewChild, xE[iVal]);
                                }
                            }
                        }
                    }
                }
                xDoc.Save("D:\\test.xml");
            }

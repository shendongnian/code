    public void CompareXml(string _feedList, string _feedRequest, string _resultPath)
        {
            FileInfo feedList = new FileInfo(_feedList);
            FileInfo feedRequest = new FileInfo(_feedRequest);
            // Load the documents
            XmlDocument feedListXmlDoc = new XmlDocument();
            feedListXmlDoc.Load(_feedList);
            // Load the documents
            XmlDocument feedRequestXmlDoc = new XmlDocument();
            feedRequestXmlDoc.Load(_feedRequest);
            // Define a single node
            XmlNode feedListNode;
            XmlNode feedRequestNode;
            // Get the root Xml element
            XmlElement feedListRoot = feedListXmlDoc.DocumentElement;
            XmlElement feedRequestRoot = feedRequestXmlDoc.DocumentElement;
            // Get a list of feeds for the stored list and the request
            XmlNodeList feedListXml = feedListRoot.GetElementsByTagName("Feed");
            XmlNodeList feedRequestXml = feedRequestRoot.GetElementsByTagName("Feed");
            bool feedLocated = false;
            int j = 0;
            try 
            {
                // loop through list of current feeds
                for (int i = 0; i < feedListXml.Count; i++)
                {
                    feedListNode = feedListXml.Item(i);
                    //create status attribute
                    XmlAttribute attr = feedListXmlDoc.CreateAttribute("status");
                    string feedListName = feedListNode.Attributes["name"].Value.ToString();
                    string feedListHash = feedListXml.Item(i).InnerText.ToString();
                    //check feed request list for a match
                    while (j < feedRequestXml.Count && feedLocated == false)
                    {
                        feedRequestNode = feedRequestXml.Item(j);
                        string feedRequestName = feedRequestNode.Attributes["name"].Value.ToString();
                        
                        //checks to see if feed names match
                        if (feedRequestName == feedListName)
                        {
                            string feedRequestHash = feedRequestXml.Item(j).InnerText.ToString();
                            //checks to see if hashCodes match
                            if (feedListHash == feedRequestHash)
                            {
                                //if name and code match, set status to ok
                                attr.Value = "ok";
                                
                                Debug.WriteLine(feedListName + " name and hash match. Status: 'ok'");
                            }
                            else 
                            {
                                //if hashCodes don't match, set status attribute to updated
                                attr.Value = "updated";
                                Debug.WriteLine(feedListName + " name matched but hash did not. Status: 'updated'");
                            }
                            feedListNode.Attributes.Append(attr);
                            feedLocated = true;
                        }
                        else
                        {
                            //names didn't match, checking to see if we're at the end of  the request list
                            if (j + 1 == feedRequestXml.Count)
                            {
                                //file name wasn't found in the request list, set status attribute to missing
                                attr.Value = "missing";
                                feedListNode.Attributes.Append(attr);
                                feedLocated = true;
                                j = 0;
                                
                                Debug.WriteLine("Reached the end of the file request list without a match. Status: 'missing'");
                            }
                            //file name wasn't located on this pass, move to next record
                            j++;
                        }
                    }
                    feedLocated = false;
                }
            }
            finally
            {
                Debug.WriteLine("Result file has been written out at " + _resultPath);
            }
            feedListXmlDoc.Save(_resultPath);
        }

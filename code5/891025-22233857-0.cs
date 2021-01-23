    public string GetIDFromList(string parameter)
        {
            string retorno = "";
            try
            {
                string path = "http://www.test.com/web/";
                // Reference to the SharePoint Lists web service:
                WSSharePointCSCLists.Lists listsWS = new WSSharePointCSCLists.Lists();
                listsWS.Url = path + "_vti_bin/lists.asmx";
                listsWS.Credentials = GetUserCredential();
                string listName = "MyList";
                string viewName = "";
                //string webID;
                string rowLimit = "500";
                // Web ID:
                webID = "098304-9098asdf-qwelkfj-eoqiula";                    
                
                XmlDocument xmlDoc = new System.Xml.XmlDocument();
                // Query em CAML (SharePoint):
                XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
                XmlNode ndViewFields =
                            xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
                XmlNode ndQueryOptions =
                            xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
                ndQueryOptions.InnerXml =
                            "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>" +
                            "<DateInUtc>TRUE</DateInUtc>" +
                            "<ViewAttributes Scope=\"RecursiveAll\" />";
                ndViewFields.InnerXml = @"<FieldRef Name='Title' /> 				       
                                            <FieldRef Name='ID' />";
                
                string caml =
                    String.Format(
                                @"<Where>
                                    <Contains>
                                        <FieldRef Name='MyColumn' />
                                        <Value Type='Text'>{0}</Value>           
                                    </Contains>                                    
                                </Where>",
                        parameter);
                ndQuery.InnerXml = caml;
                XmlNode retornoWS = listsWS.GetListItems(listName, null, ndQuery,
                                                             ndViewFields, rowLimit,
                                                             ndQueryOptions, webID);
                retorno = retornoWS.InnerXml;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                throw;
            }
            return retorno;
        }
        public NetworkCredential GetUserCredential()
        {
            return new System.Net.NetworkCredential("<username>",
                                                    "<password>",
                                                    "<domain>");
        }

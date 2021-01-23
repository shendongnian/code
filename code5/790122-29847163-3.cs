    public void CreateXml(string XmlPath)
    { 
    try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Name = string.Empty;
                        int Age = 0;
                        int Experience = 0;
    
                        Name = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                        Age = int.Parse(ds.Tables[0].Rows[0]["EmployeeAge"].ToString());
                        Experience = int.Parse(ds.Tables[0].Rows[0]["EmployeeExperience"].ToString());
    
                        string xml = XmlTemplate().ToString().Replace("EmpName", Name).Replace("EmpAge", Age.ToString(),Replace("EmpExperience", Experience.ToString());
                        XmlPath = XmlPath + "Employee_" + Name + ".xml";
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.LoadXml(xml);
                        xdoc.Save(XmlPath);
                        lblMessage.Text = "XML Created Successfully.";
                    }
                    else
                    {
                        lblMessage.Text = "InValid Employee ID.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
    }
    public string XmlTemplate()
    {
    
                string Xml = "<Employee>" +
                                "<Name>EmpName</Name>" +
                                "<Age>EmpAge</Age>" +
    	          "<Experience>EmpExperience</Experience>" +
                                "</Employee>";
                return Xml;
    }

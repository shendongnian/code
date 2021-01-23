            DataSet dsresult = new DataSet();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Employees><Employee><Name>Adams John</Name><Age>35</Age><Gender>M</Gender><Salary>65000</Salary></Employee><Employee><Name>Mary Jane</Name> <Age>35</Age><Gender>F</Gender><Salary>75000</Salary></Employee></Employees>");
            XmlElement exelement = doc.DocumentElement;
            if (exelement != null)
            {
                XmlNodeReader nodereader = new XmlNodeReader(exelement);
                dsresult.ReadXml(nodereader, XmlReadMode.Auto);
                GridView1.DataSource = dsresult;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

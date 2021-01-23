    sqlQuery = "update tblCCBT_Step_Page_Text_Xml set Xml_XmlData.modify('replace value of (/page/*[position()="+xmlNodeIndex+"]/text())[1] with " + newValue + " ') where Xml_Id = " + xmlId;
                string a = Server.MapPath("~/Content/dbScripts");
                string dt = System.DateTime.Now.ToShortTimeString();
                dt = dt.Replace(":", "-");
                FileStream fs1 = new FileStream(a + "\\editNode_"+dt+".sql", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.Write(sqlQuery);
                writer.Close();

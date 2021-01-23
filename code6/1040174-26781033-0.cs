                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable("articles");
                dataTable.Columns.Add("name", typeof(string));
                dataTable.Columns.Add("id", typeof(string));
                dataSet.Tables.Add(dataTable);
    
                string xmlData = "<XmlDS><articles><name>name1</name><id>R12</id></articles><articles><name>name2</name><id>R13</id></articles><articles><name>name3</name><id>R14</id></articles><articles><name>name4</name><id>R15</id></articles><articles><name>name5</name><id>R16</id></articles><articles><name>name6</name><id>R17</id></articles><articles><name>name7</name><id>R18</id></articles><articles><name>name8</name><id>R19</id></articles></XmlDS>";
    
                System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);
    
                dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);
    
                DataSet dataSet2 = new DataSet();
                DataTable dataTable2 = new DataTable("articles");
                dataTable2.Columns.Add("name", typeof(string));
                dataTable2.Columns.Add("id", typeof(string));
                dataSet2.Tables.Add(dataTable2);
    
                string xmlData2 = "<XmlDS><articles><name>name1</name><id>R12</id></articles><articles><name>name2</name><id>R13</id></articles><articles><name>nameTT</name><id>R14</id></articles><articles><name>name3</name><id>R20</id></articles></XmlDS>";
                System.IO.StringReader xmlSR2 = new System.IO.StringReader(xmlData2);
    
                dataSet2.ReadXml(xmlSR2, XmlReadMode.IgnoreSchema);
    
                var d1 = dataSet.Tables[0].AsEnumerable();
                var d2 = dataSet2.Tables[0].AsEnumerable();
                var result = d1.Where(a => d2.All(dt => dt["id"].ToString() != a["id"].ToString() || dt["name"].ToString() != a["name"].ToString())).ToList();

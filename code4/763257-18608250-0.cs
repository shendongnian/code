    DataSet ds = new DataSet();
                if (File.Exists(@"C:\Users\rs\Desktop\Test\save.xml"))
                {
                    ds.ReadXml(@"C:\Users\rs\Desktop\Test\save.xml");
    
                    ds.Tables[0].Rows.Add(txt_Name.Text, combox_Priority.Text, txt_Beginn.Text, txt_EndSoll.Text, txt_EndIst.Text, txt_Bemerkungen.Text);
                    ds.WriteXml(@"C:\Users\rs\Desktop\Test\save.xml");
                }
                else
                {
                    DataTable datatable = new DataTable();
                    datatable.TableName = "SaveInput";
    
                    DataColumn dc1 = new DataColumn("Name");
                    DataColumn dc2 = new DataColumn("Priority");
                    DataColumn dc3 = new DataColumn("StartDate");
                    DataColumn dc4 = new DataColumn("EndDateSoll");
                    DataColumn dc5 = new DataColumn("EndDateIst");
                    DataColumn dc6 = new DataColumn("Comment");
    
                    datatable.Columns.Add(dc1);
                    datatable.Columns.Add(dc2);
                    datatable.Columns.Add(dc3);
                    datatable.Columns.Add(dc4);
                    datatable.Columns.Add(dc5);
                    datatable.Columns.Add(dc6);
    
                    datatable.Rows.Add(txt_Name.Text, combox_Priority.Text, txt_Beginn.Text, txt_EndSoll.Text, txt_EndIst.Text, txt_Bemerkungen.Text);
    
                    DataSet dataset = new DataSet();
    
                    dataset.Tables.Add(datatable);
                    dataset.DataSetName = "MyProgram";
    
                    dataset.WriteXml(@"C:\Users\rs\Desktop\Test\save.xml");
                }

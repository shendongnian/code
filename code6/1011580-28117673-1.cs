            String textLine = string.Empty;
            String[] splitLine;
            bool columncreater = false;
            try
            {
                StreamReader objReaders = new StreamReader(file);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                int datagridrowindex =-1;
                do
                {
                    textLine = objReaders.ReadLine();
                  datagridrowindex=  datagridrowindex + 1;
                    if (textLine != "")
                    {
                        splitLine = textLine.Split(',');
                        
                        //if (splitLine[0] != "" || splitLine[1] != "")
                        //{
                        //    dataGridView1.Rows.Add(splitLine[0]);
                            
                        //}
                       
                            if (columncreater ==false )
                            {
                                for (int i = 0; i < splitLine.Length; i++)
                                {
                                    dataGridView1.Columns.Add("C" + i + "", "C" + i + "");
                                }
                                columncreater = true;
                            }
                            
                        
                        dataGridView1.Rows.Add(splitLine);
                        int cc = dataGridView1.Columns.Count;
                        int rr = dataGridView1.Rows.Count;
                       
                    }
                } while (objReaders.Peek() != -1);
            }
            catch (Exception ex)
            {
            }
        }

    string test = "";
                            for (clm = 0; clm < columncount; clm++)
                            {
                                StringBuilder sb = new Stringbuilder();
                                sb.Append(ExportTable.Rows[rw][clm].ToString());
    
                                if (clm != 3 && clm != 5 && clm != 6)
                                {
                                    sb.Insert(0,"'");
                                    sb.Append("'");
                                }
    
                                test += sb;
    
                                if (clm != columncount - 1) // add a comma if it's not the last column
                                {
                                    test += ",";
                                }
    
                            }

    List<string> xml_string = new List<string>();
    xml_string.Add("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
    xml_string.Add("anything you need as header");
    foreach(string current_string in your_object_of_DataTable)
    {
   
     if(current_string!=null || current_string.Trim()!="")
        {
          xml_string.Add("<Your Tag>"+current_string+"</Your Tag>");
        }
    }
     try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\xml_file_name.xml"))
                    {
                        foreach (string line in xml_string)
                        {
                            file.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("File exported.");
                }

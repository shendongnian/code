    string path = Server.MapPath("D:\\RetailAgreement\\" + filePath1");
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                string Outgoingfile = "myfile.xlsx";
                if (file.Exists)
                {
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Outgoingfile);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    Response.Close();
    
                }
                else
                {
                    Response.Write("This file does not exist.");
                }

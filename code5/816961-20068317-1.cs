                    String [] JSLines=System.IO.File.ReadAllLines("c:\\myfile.js");
                    String strDate = "";
                    for(int i=0;i<JSLines.Length;i++)
                    {                        
                        strDate=JSLines[i].Substring(JSLines[i].LastIndexOf("(")+1,8);               
                        DateTime myDate = DateTime.ParseExact(strDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);                               
                    }

       public Dictionary<string, BodyContent> ParseContent(string content)
        {
            string[] list = content.Split(new string[] { boundary }, StringSplitOptions.RemoveEmptyEntries);
            string name="", val="";
            Dictionary<string, BodyContent> temp = new Dictionary<string, BodyContent>();
            foreach (String s in list)
            {
                if (s == "--" || s == "--\r\n")
                {
                    //Do nothing.
                }
                else
                {
                    string[] token = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    val = "";
                    name = "";
                    foreach (string x in token)
                    {
                        if(x.StartsWith("Content-Disposition"))
                        {
                            //Name
                            name = x.Substring(x.IndexOf("name=")+5, x.Length - x.IndexOf("name=")-5);
                            name = name.Replace(@"\","");
                            name = name.Replace("\"","");
                        }
                        if (x.StartsWith("--"))
                        {
                            break;
                        }
                        if (!x.StartsWith("--") && !x.StartsWith("Content-Disposition"))
                        {
                            val = x;
                        }
                    }
                    if (name.Length > 0)
                    {
                        BodyContent b = new BodyContent();
                        b.content = name;
                        if (val.Length == 0)
                        {
                            b.value = "";
                        }
                        else
                        {
                            b.value = val;
                        }
                        temp.Add(name, b);
                    }
                }
            }
            return temp;        
        }

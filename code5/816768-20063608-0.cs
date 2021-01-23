                    if (!File.Exists("clients.xml"))
                    {
                        List<string> lines = new List<string>();
                        lines.Add("<clients>");
                        lines.Add("</clients>");
                        File.WriteAllLines("clients.xml", lines);
                    }
                     if (!File.Exists("cases.xml"))
                    {
                        List<string> lines = new List<string>();
                        lines.Add("<names>");
                        lines.Add("</names>");
                        File.WriteAllLines("cases.xml", lines);
                    }
                    if (!File.Exists("files.xml"))
                    {
                        List<string> lines = new List<string>();
                        lines.Add("<num>");
                        lines.Add("</num>");
                        File.WriteAllLines("files.xml", lines);
                    }
                    else
                    {
                        return;
                    }

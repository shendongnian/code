            string path = @"http://localhost/page.html";
            XDocument myX = XDocument.Load(path);
            string field1 = "";
            string field2 = "";
            bool flag = true;
            foreach (var name in myX.Root.DescendantNodes().OfType<XElement>())
            {
                // get the first element
                if (name.Name.LocalName == "td" && flag)
                {
                    field1 = (string)name + "\n";
                    flag = false;
                }
                // get the second element
                else if (name.Name.LocalName == "td")
                {
                    field2 = (string)name + "\n";
                    flag = true;
                }
            }
        }

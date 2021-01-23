            XDocument doc = XDocument.Load("input.xml");
            foreach (XComment start in doc.DescendantNodes().OfType<XComment>().Where(c => c.Value.StartsWith(" START")).ToList())
            {
                XComment end = start.NodesAfterSelf().OfType<XComment>().FirstOrDefault(c => c.Value.StartsWith(" END"));
                if (end != null)
                {
                    foreach (XComment comment in end.NodesBeforeSelf().OfType<XComment>().Intersect(start.NodesAfterSelf().OfType<XComment>()).ToList())
                    {
                        comment.ReplaceWith(XElement.Parse("<dummy>" + comment.Value + "</dummy>").Nodes());
                    }
                    // if wanted/needed
                    start.Remove();
                    end.Remove();
                }
            }
            doc.Save("output.xml");

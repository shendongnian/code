            foreach (var gt in gameTypes.Where(gt => gt != null && gt.InnerText != null && this.rtbHtmlReceived != null))
            {
                var cells = gt.NextSibling.NextSibling.ChildNodes.Descendants("tr");
                foreach (var item in cells)
                {
                    rtbHtmlReceived.AppendText("Type: " + item.FirstChild.InnerText + ": ");
                    rtbHtmlReceived.AppendText("Value: " + item.LastChild.InnerText + "\n");
                }
            }

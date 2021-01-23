                // Get all option elements
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//option");
            foreach (HtmlNode node in nodes)
            {
                // Get the outer position of the NextSibling (which would be the text we want to surround with </option>)
                int nextPosition = rawProvinces.IndexOf(node.NextSibling.OuterHtml) + node.NextSibling.OuterHtml.Trim().Length;
                // Check if there isn't already a </option> element
                if (!rawProvinces.Substring(nextPosition, 8).StartsWith("</option"))
                {
                    // Add the element
                    rawProvinces = rawProvinces.Insert(nextPosition, "</option>");
                }
            }

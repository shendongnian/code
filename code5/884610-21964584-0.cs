    var data = @"<Data>" + 
                              "<ParentID>00000000-0000-0000-0000-000000000000</ParentID>" + 
                              "<Content>&lt;ContentControl xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"&gt;"+ 
                        "&lt;Grid&gt;&lt;Image Source=\".//Resources/Images/start.png\" Tag=\"Start\" ToolTip=\"Start\" IsHitTestVisible=\"False\" /&gt;&lt;/Grid&gt;&lt;/ContentControl&gt;" + 
                        "</Content>" + 
                        "</Data>";
            var root = XElement.Parse(data);
            var contentValue = root.Element("Content").Value; 
            var contentXml = XElement.Parse(contentValue);
            var ns = contentXml.Name.Namespace; // retrieve the namespace 
            var imageTagValue = contentXml.Element(ns+"Grid").Element(ns+"Image").Attribute("Tag").Value; // 

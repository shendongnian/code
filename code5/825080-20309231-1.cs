     private string PrepareHtmlContent(List<DataRow> dataTable)
        {
            var htmlDocument = new HtmlDocument();
            var html = EmailTemplates.GetTemplate("yourTemplate");
            htmlDocument.LoadHtml(html);
            var recordsContainerNode = htmlDocument.GetElementbyId("dataTable");
            if (recordsContainerNode != null)
            {
                var innerHtml = "";
                foreach (var entry in dataTable)
                {
              
                    innerHtml += "<tr>";
                    innerHtml += "<td>" + entry.PrimaryImage + "</td> ";
                    innerHtml += "<td>" + entry.Model + "</td> ";
					innerHtml += "<td>" + entry.AskingPrice + "</td> ";
                    innerHtml += "</tr>";
                }
				
                recordsContainerNode.InnerHtml = innerHtml;
            }
			
	     using (var stringWriter = new StringWriter())
            {
                htmlDocument.Save(stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
     }

    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter)) //Always enclose in 'using' for cleaner code
    for (int i = 1; i < files.Length; i++)
    {
    	//Write the starting 'a' tag
       	writer.AddAttribute(HtmlTextWriterAttribute.Href, "images/gallery/projects/" + Path.GetFileName(temp));
    	writer.RenderBeginTag(HtmlTextWriterTag.A); 
    	
    	//Write the starting 'img' tag
    	writer.AddAttribute(HtmlTextWriterAttribute.Src, "images/gallery/projects/" + Path.GetFileName(files[i]));
    	writer.RenderBeginTag(HtmlTextWriterTag.Img);
    
    	//Close the 'img' tag
    	writer.RenderEndTag();
    
    	//Close the 'a' tag
    	writer.RenderEndTag();	
    }
    
    var generatedHtml = stringWriter.ToString(); //The final HTML

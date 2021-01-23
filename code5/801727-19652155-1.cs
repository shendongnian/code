    HtmlDocument doc = new HtmlDocument();
    doc.Load("file.htm");
    bool previousWasHeading = false;
    foreach(HtmlNode div in doc.DocumentElement.SelectNodes("//div"))
    {
        if (previousWasHeading)
        {
            // Previous <div> was the heading, this one is the heading data.
            headingsData = div.Text;
            previousWasHeading = false;
            break; // Stop after first heading/headingData
        }
        else if (div.InnerText.Contains("effective date") || div.InnerText.Contains("eff date"))
        {
            // This this <div> is the heading.
            heading = div.Text;
            previousWasHeading = true;
        }
    }
    

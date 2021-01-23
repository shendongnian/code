    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // Save variables in Session object
        Session["firstName"] = firstNameTextBox.Text;
        Session["lastName"] = lastNameTextBox.Text;
        Session["gender"] = maleRadioButton.Checked ? "Male" : "Female";
        Session["haveCar"] = haveCarCheckBox.Checked;
        Session["carType"] = carTypeDropDownList.SelectedValue;
        Session["comments"] = commentsTextBox.Text;
    
        // Execute the Display_Session_Variables.aspx page and get the HTML string 
        // rendered by this page
        TextWriter outTextWriter = new StringWriter();
        Server.Execute("Display_Session_Variables.aspx", outTextWriter);
    
        string htmlStringToConvert = outTextWriter.ToString();
    
        // Create a HTML to PDF converter object with default settings
        HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
    
        // Set license key received after purchase to use the converter in licensed mode
        // Leave it not set to use the converter in demo mode
        htmlToPdfConverter.LicenseKey = "fvDh8eDx4fHg4P/h8eLg/+Dj/+jo6Og=";
    
        // Use the current page URL as base URL
        string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri;
    
        // Convert the page HTML string to a PDF document in a memory buffer
        byte[] outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlStringToConvert, baseUrl);
    
        // Send the PDF as response to browser
    
        // Set response content type
        Response.AddHeader("Content-Type", "application/pdf");
    
        // Instruct the browser to open the PDF file as an attachment or inline
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Convert_Page_in_Same_Session.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
        // Write the PDF document buffer to HTTP response
        Response.BinaryWrite(outPdfBuffer);
    
        // End the HTTP response and stop the current page processing
        Response.End();
    }
    
    
    Display Session Variables in Converted HTML Page
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            firstNameLabel.Text = Session["firstName"] != null ? (String)Session["firstName"] : String.Empty;
            lastNameLabel.Text = Session["lastName"] != null ? (String)Session["lastName"] : String.Empty;
            genderLabel.Text = Session["gender"] != null ? (String)Session["gender"] : String.Empty;
    
            bool iHaveCar = Session["haveCar"] != null ? (bool)Session["haveCar"] : false;
            haveCarLabel.Text = iHaveCar ? "Yes" : "No";
            carTypePanel.Visible = iHaveCar;
            carTypeLabel.Text = iHaveCar && Session["carType"] != null ? (String)Session["carType"] : String.Empty;
    
            commentsLabel.Text = Session["comments"] != null ? (String)Session["comments"] : String.Empty;
        }
    }

    // Declare a local instance of a Page and add your control to it
    var page = new Page();
    var control = new MyTest();
    
    // Add your control to an HTML form
    var form = new HtmlForm();
    form.Controls.Add(control);
    
    // Add the form to the page
    page.Controls.Add(form);                
    var sw = new StringWriter();            
    
    // Execute the page, which will in turn run the lifecycle
    HttpContext.Current.Server.Execute(page, sw, false);           
    
    // Get the output of the control and the form that wraps it
    var output = sw.ToString();

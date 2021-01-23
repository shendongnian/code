    // Declare a local instance of a Page and add your control to it
    var page = new Page();
    var control = new MyTest();
    page.Controls.Add(control);
                            
    var sw = new StringWriter();            
    
    // Execute the page, which will run the lifecycle
    HttpContext.Current.Server.Execute(page, sw, false);           
    
    // Get the output of your control
    var output = sw.ToString();

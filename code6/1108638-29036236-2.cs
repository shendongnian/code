    // Get a service provider – how you do this depends on the context:
    IServiceProvider serviceProvider = dte; // or dslDiagram.Store, for example 
    // Get the text template service:
    ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) 
                                                         as ITextTemplating;
    ITextTemplatingSessionHost host = t4 as ITextTemplatingSessionHost;
    // Create a Session in which to pass parameters:
    host.Session = host.CreateSession();
    // Add parameter values to the Session:
    session["MyUserName"] = "Bob";
    // Process a text template:
    string result = t4.ProcessTemplate("MyTemplateFile.t4",
                                        System.IO.File.ReadAllText("MyTemplateFile.t4"));

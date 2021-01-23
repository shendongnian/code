    // 1) Get all the published applications list by calling GetApplicationsByCredentialsEx 
    //    web service.
    // 2) create an ImageButton for each application
    // 3) Create Image for the application
    // 4) Add it to the AppList panel.
    // 5) Set the event handler for each ImageButton, so when clicking it the associated 
    //    application will run calling the web service
    ApplicationItemEx[] items = proxy.GetApplicationsByCredentialsEx
        (credentials, Request.UserHostName,
    Request.UserHostAddress, new  string[] { "icon","icon-info"}, new string[]{ "all" },
    new string[] { "all"});
    
    //loop for each published application
    for (int i = 0; i < items.Length; i++) {
    //create the ImageButton
    System.Web.UI.WebControls.ImageButton app = new System.Web.UI.WebControls.ImageButton();
    
    //set the Image URL to the created image
    app.ImageUrl = createIcon(items[i].InternalName,items[i].Icon);
    
    //set the ToolTip to the name of the published application
    app.ToolTip = items[i].InternalName;
    
    //add the ImageButton to the AppList panel
    AppList.Controls.Add(app);
    
    //set the event handler for the ImageButton.
    app.Click += new
    System.Web.UI.ImageClickEventHandler(this.OnApplicationClicked); 

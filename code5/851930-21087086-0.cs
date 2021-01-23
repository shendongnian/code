    TreeProvider tree = new TreeProvider(CMSContext.CurrentUser);
    
    // Select root at parent
    TreeNode parentNode = tree.SelectSingleNode(CMSContext.CurrentSiteName, "/", "en-us");
    
    // Create a new instance of the Tree node
    TreeNode newNode = TreeNode.New("CMS.MenuItem", tree);
    
    // Set the document's properties
    newNode.DocumentName = "Document name";
    newNode.DocumentCulture = "en-us";
    
    // Set document type specific fields
    newNode.SetValue("Field1", "value");
    
    // Insert the document into the content tree
    DocumentHelper.InsertDocument(newNode, parentNode, tree);
      

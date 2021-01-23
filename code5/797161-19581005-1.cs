            using umbraco.cms.businesslogic.web;
            DocumentType dt = DocumentType.GetByAlias("alias");
            // The umbraco user that should create the document, 
            // 0 is the umbraco system user, and always exists
            umbraco.BusinessLogic.User u = new umbraco.BusinessLogic.User(0);
            //Replace 1055 with id of parent node
            Document doc = Document.MakeNew("new child node name", dt, u, 1055);
           
            //after creating the document, prepare it for publishing 
            doc.Publish(u);
            //Tell umbraco to publish the document
            umbraco.library.UpdateDocumentCache(doc.Id);

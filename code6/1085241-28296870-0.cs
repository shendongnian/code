    var itemID=mainPage.Fields["Address"].value;
    Item targetItem=Sitecore.Context.Database.GetItem(itemID);
    
    if (mainPage.TemplateID.ToString() == "{27A9692F-AE94-4507-8714-5BBBE1DB88FC}")
                {
                    sl += "<span class=\"address\">" + targetItem.DisplayName +"</span>";
                }                            
                else
                {
                }

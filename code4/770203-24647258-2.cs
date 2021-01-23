    public ActionResult ViewList(){
       var model = new List<ListOfItems>();
       var listItem1 = new ListItem
       {
           Content = "My first list item!"
       };
       var listItem2 = new ListItem
       {
           Content = "My second list item!"
       };
    
       var listOfItems1 = new ListOfItems
       {
           Id = 1
       };
    
       listOfItems1.Item.Add(listItem1);
       listOfItems1.Item.Add(listItem2);
    
       model.Add(listOfItems1);
       return View(model);
    }

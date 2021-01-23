    protected void Page_Load(object sender, EventArgs e)
    {
       List<tblDetal> lstDetail = objDal.GetData();
       //New Code
       List<MenuItem> listOfChildrenToDelete;
       foreach(MenuItem parent in menuBar.Items)
       {
           if(parent.ChildItems.Count > 0)
           {
               //Instantiate new temporary List
               listOfChildrenToDelete = new List<MenuItem>();
               foreach(MenuItem child in parent.ChildItems)
               {
                    bool showItem = false;
                    foreach(var item in lstDetail)
                    {
                        if(Convert.ToInt32(child.value) == item.FormId)
                        {
                           showItem = true;
                           break;
                        }
                    }
                    if(showItem==false)
                    {
                        //Add to new temporary list
                        listOfChildrenToDelete.Add(child);
                    }
                }
                //Added Code
               foreach(MenuItem childToDelete in listOfChildrenToDelete)
               {
                    //Delete after you are no longer looking at that collection.
                    parent.ChildItems.Remove(childToDelete);
               }
            }
        }
    }

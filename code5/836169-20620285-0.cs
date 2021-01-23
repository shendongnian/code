    public ActionResult UpdateUser([Bind(Prefix = "models")]IEnumerable<UserInfo> updatedItems)
    {
    foreach (var updatedItem in updatedItems.AsNotNull())
                {
                       //--your code---//
                }
    }
    
    public ActionResult DeleteUser([Bind(Prefix = "models")]IEnumerable<UserInfo> deletedItems)
    {
    foreach (var deletedItem in deletedItems.AsNotNull())
                {
                       //--your code---//
                }
    }

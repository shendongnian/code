    // keep in mind that `id` is the `id` of the clicked on node.
    
    // DELETE api/region/5
    public HttpResponseMessage Delete(int id)
    {
         Region region = db.Regions.Find(id);
         List<int> tempRegionIds = new List<int>();
         List<int> immediateChildrenIds = (from i in db.Regions where i.ParentId == id select i.Id).ToList();
         List<int> regionsToDeleteIds = new List<int>();
         // the below is needed because we need to add the Id of the clicked on node to make sure it gets deleted as well
         regionsToDeleteIds.Add(region.Id);
         // we can't make this a static method because that would require static member
         // variables, and static member variables persist throughout each recursion
         HelperClasses.HandleChildren.Children GetChildren = new HelperClasses.HandleChildren.Children();
         // see below this code block for the GetChildrenIds(...) method
         tempRegionIds = GetChildren.GetChildrenIds(immediateChildrenIds);
         // here, we're just adding to regionsToDeleteIds the children of the traversed parent
         foreach (int tempRegionId in tempRegionIds)
         {
             regionsToDeleteIds.Add(tempRegionId);
         }
         // reverse the order so it goes youngest to oldest (child to grandparent)
         // is it necessary?  I don't know honestly.  I just wanted to make sure that
         // the lowest level child got deleted first (the one that didn't have any children)
         regionsToDeleteIds.Reverse(0, regionsToDeleteIds.Count);
         if (regionsToDeleteIds == null)
         {
             return Request.CreateResponse(HttpStatusCode.NotFound);
         }
         foreach (int regionId in regionsToDeleteIds)
         {
             // here we're finding the object based on the passed in Id and deleting it
             Region deleteRegion = db.Regions.Find(regionId);
             db.Regions.Remove(deleteRegion);
         }
         ...

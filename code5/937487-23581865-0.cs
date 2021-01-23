        ///If image is not in list then add the image to the list
        
    public void AddNew (List<AccomodationImageModel> masterList, AccomodationImageModel theImage)
    {
        masterList.Add(theImage);
    }
        
        /// If Image is in List then change listitem with new one
        
    public void Update (List<AccomodationImageModel> masterList, int OldOnesID, AccomodationImageModel theNew)
    {
        masterList[OldOnesID] = theNew;
    }
        
        /// If Image should delete then removes the image from list
        
    public void Delete (List<AccomodationImageModel> imgList, AccomodationImageModel theImageToDelete)
    {
        masterList.Remove(theImageToDelete);
    }
        
        
        /// this method checks the image state and do the work
        
    public void CheckState (List<AccommodationImageModel> masterList, AccomodationImageModel theImage, bool deleteIt)
    {
        
        
           for(int i = 0; i < masterList.Count; i++)
           {
        
             if (deleteIt)
             {
                Delete(masterList, theImage);
             }
    
             else
             {
               if(theImage.ID == 0)
               {
                 AddNew(masterList, theImage);
               }
        
               if(masterList[i].ID == theImage.ID)
               {
                 Update(masterList, i, theImage);
               }
           }
    }

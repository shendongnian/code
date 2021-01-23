    public void GetImageThumbnailFromByteArray(Guid? profileId)
    		{	
    
    			Profile profile = // Get profile by profileId
    			Byte[] image = profile.Image;
    			
    			new WebImage(image).Write();
    
    		}

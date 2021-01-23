    Action<UI.Interactivity.InteractionRequest.YesNoDialog.YesNoDialogConfirmation> callback = c =>
    		{
    			if (c.Yes)
    			{
    				foreach (var tiffFile in dialog.Files.Where(x=>x.Extension.ToUpper() == "TIFF" || x.Extension.ToUpper() == "TIF"))
    				{
    					
    
    					using (System.IO.Stream tiffFileStream = tiffFile.OpenRead())
    					{
    						byte[] tiffFileBytes =
    							new byte[System.Convert.ToInt32(tiffFileStream.Length)];
    						tiffFileStream.Read(tiffFileBytes, 0, tiffFileBytes.Length);
    
    						Images imageRec2 = this.CreateNew<Images>();
    						imageRec2.Description = tiffFile.Name;
    						imageRec2.Extension = "pdf";
    						// some more inits and sutff here too.
    						ImagingUtilities.ConvertImgToPDF(tiffFileBytes, imageRec2)
    					}
    				}
    			}
    			else
    			{
    				this.SaveAndAddImage(imageRec, fileBytes, file.Name);
    			}
    		};
    
    	this.OpenYesNoDialog("Do you want to convert Tiff files to PDF before saving them?", callback);
    
    
    //tiff already handled
    foreach (var file in dialog.Files.Where(x=>x.Conditions&& !x.Extension.ToUpper() == "TIFF" && !x.Extension.ToUpper() == "TIF").AsEnumerable())
    {
        Images imageRec = this.CreateNew<Images>();
        imageRec.Description = file.Name;
        imageRec.AsOfDate = System.DateTime.Now;
        // inits some more fields here 
    
    	using (System.IO.Stream fileStream = file.OpenRead())
    	{
    		byte[] fileBytes = new byte[System.Convert.ToInt32(fileStream.Length)];
    		fileStream.Read(fileBytes, 0, fileBytes.Length);
    
    		
    		this.SaveAndAddImage(imageRec, fileBytes, file.Name);
    		
    	}
    
    }
      

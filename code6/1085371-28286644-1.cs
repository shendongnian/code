       var askedToConvert = false;
       var convertTiff = false;
       foreach (var file in dialog.Files.Where(someConditionsGoHere).AsEnumerable())
        {
            Images imageRec = this.CreateNew<Images>();
            imageRec.Description = file.Name;
            imageRec.AsOfDate = System.DateTime.Now;
            // inits some more fields here 
           
        	
            using (System.IO.Stream fileStream = file.OpenRead())
            {
                byte[] fileBytes = new byte[System.Convert.ToInt32(fileStream.Length)];
                fileStream.Read(fileBytes, 0, fileBytes.Length);
        
                if (imageRec.Extension.ToUpper() == "TIFF" || imageRec.Extension.ToUpper() == "TIF")
                {
                   
                     if(!askedToConvert) 
        	         {		    
        		         this.OpenYesNoDialog("Do you want to convert Tiff files to PDF before saving them?", c=>  {
        			       askedToConvert = true;
        			       convertTiff = c.Yes;
        		         });
        	         }
        	         if(convertTiff) 
        	         {			
        			
        		         imageRec.Extension = "pdf";
        		         // some more inits and sutff here too.		        
               		     fileBytes = ImagingUtilities.ConvertImgToPDF(fileBytes) ; // this needs to return new bytes   	
                               		    
        	      } 
                     
                  this.SaveAndAddImage(imageRec, fileBytes, file.Name);
                
            }
        }

    public ControlsTypeHere PrintImages(int take, int skip)
    {
    	int filesPrinted;
    	
    	for (int i = skip; i < Files.Count; i++)
    	{
    		if(filesPrinted >= take)
    			break;
    			
    		HtmlImage image=new HtmlImage();
    		image.ID="ImageAN"+i.ToString();
    		image.Src=Files[i].ToString();
    		image.Alt="PrintImage";
    		image.Attributes.Add("class","PrintImage");
    
    		div_Print.Controls.Add(image);
    		
    		filesPrinted++;
    	}
    	
    	return div_Print.Controls;
    }

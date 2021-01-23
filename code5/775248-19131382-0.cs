    public class AccordionItem
    {
        public string Title { get; set; }
        public string Body { get; set; }
    	public ImageRegion Image { get ; set ; }
    
    	public AccordionItem() {
    		Image = new ImageRegion() ;
    	}
    }

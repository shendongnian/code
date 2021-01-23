    public class CustomCell : UITableViewCell
    {
     
    CustomCell
    {
    
    //Create text fields here
    UITextView TextField1=new UITextView();
    this.AddSubView(TextField1);
    
    }
    
    public override void LayoutSubviews ()
    {
    
    // set location of text fields in cell as below
    
     TextField1.Frame=new RectangleF( 32, 8, 60, 15);
    
    }
    		
    
    }//end class

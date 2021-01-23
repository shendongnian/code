    public class XYZ
    {    
       xmlData myXML; 
    
       public XYZ()
       {
           myXML = new xmlData();
       }
    
       private void Show_btn_Click(object sender, EventArgs e)
       {            
           //do something.....
           myXML.xmlAttributes = "blah"
       }
    
       private void Submit_btn_Click(object sender, EventArgs e)
       {
          // Here you can work myXML.xmlAttributes
       }    
    }

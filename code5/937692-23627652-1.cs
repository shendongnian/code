    public class Ribbon : IRibbonExtensibility
    {
    	private static IRibbonUI ribbon;
    	private string buttonText;
    	private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var wb = this.Application;
            ((Word.ApplicationEvents4_Event)wb).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(Application_NewDocument);
    
        }
        /// <summary>
        /// When the new button is pressed, the save should be enabled
        /// </summary>
        /// <param name="Doc"></param>
        void Application_NewDocument(Microsoft.Office.Interop.Word.Document Doc)
        {
    		buttonText = "New Document Created";
    		ribbon.InvalidateControl("btnTest");
        }
    
    	 public string get_LabelName(IRibbonControl control)
    	{
    		return buttonText;
    	}
    }
    	

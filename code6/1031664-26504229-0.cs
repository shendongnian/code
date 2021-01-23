    namespace Bob
    {
    	public class FormLucy
    	{
    		private BindingList<xml.Table> table = new BindingList<xml.Table>();
    		
    		// your form stuff.. 
    		
    		protected void ButtonClick(object sender, EventArgs e)
    		{
    			var frm = new FormTracy(table);
    			
    			// init your forms properties, position etc
    			
    			fmr.ShowDialog();
    		}
    	}
    }

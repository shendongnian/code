    public class Editor : UITypeEditor
    	{
    		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
    		{				
    			if (provider != null)
    			{
    				IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
    				
    				if (service != null)
    				{
    					using (MyEditorUIDialog dialog = new MyEditorUIDialog ())
    					{
    						DialogResult result = dialog.ShowDialog();
    						if (result == DialogResult.OK)
    							value = dialog.MyReturnValue;
    					}				
    				}
    			}		
    			
    			return value;
    		}
    
    		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
    		{
    			return UITypeEditorEditStyle.Modal;
    		}
    	}

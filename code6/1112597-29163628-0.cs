    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;
    using System.Reflection;
    
    namespace PageControls
    {
        public partial class PropertyGridEditor : Form
        {
            public object Result;
    
            public static event EventHandler<PropertyValueChangedEventArgs> PropertyValueChangedStatic;
            public event EventHandler<PropertyValueChangedEventArgs> PropertyValueChanged;
    
            public PropertyGridEditor(object[] obj_to_edit)
            {
                InitializeComponent();
    
                this.prop_grid.SelectedObjects = obj_to_edit;
    
                this.Result = obj_to_edit[0];
            }
    
            private void PropertyGridEditor_Load(object sender, EventArgs e)
            {
                
            }
    
            private void PropertyGridEditor_FormClosed(object sender, FormClosedEventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
    
            private void prop_grid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                var evt = PropertyGridEditor.PropertyValueChangedStatic;
    
                if (evt != null)
                    evt(s, e);
    
                var evt2 = this.PropertyValueChanged;
    
                if (evt2 != null)
                    evt2(s, e);
            }
        }
    
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public class InnerPropertyGridEditor : UITypeEditor
        {
            public InnerPropertyGridEditor()
            {
    
            }
    
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                // Indicates that this editor can display a Form-based interface. 
                return UITypeEditorEditStyle.Modal;
            }
    
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                // Attempts to obtain an IWindowsFormsEditorService.
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
    
                if (edSvc == null)
                    return null;
    
                object[] values = new object[context.Instance is object[] ? ((object[])context.Instance).Length : 1];
    
                if (context.Instance is object[])
                    for (int i = 0; i < ((object[])context.Instance).Length; i++)
                    {
                        PropertyInfo pi = ((object[])context.Instance)[i].GetType().GetProperty(context.PropertyDescriptor.Name);
                        values[i] = pi != null ? pi.GetValue(((object[])context.Instance)[i], null) : null;
                    }
                else
                    values[0] = value;
    
                using (PropertyGridEditor form = new PropertyGridEditor(values))
                    if (edSvc.ShowDialog(form) == DialogResult.OK)
                        return form.Result;
    
                return value; // If OK was not pressed, return the original value 
            }
        }
    }

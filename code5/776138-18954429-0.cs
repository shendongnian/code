    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
       
        public class MyType
        {
            [TypeConverter(typeof(GiveMeOptionsConverter))]
            public string SomeProperty {get;set;}
    
    
            private class GiveMeOptionsConverter : TypeConverter
            {
                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }
                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return false; // true is drop-down; false is combo
                }
                public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    // this gives you the `MyType` instance if you need it
                    var obj = (MyType)context.Instance;
    
                    return new StandardValuesCollection(
                        new[] { "abc", "def", "ghi" });
                }
            }
        }
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                using (var grid = new PropertyGrid {
                    Dock = DockStyle.Fill,
                    SelectedObject = new MyType()
                })
                using (var form = new Form { Controls = { grid } })
                {
                    Application.Run(form);
                }
                
            }
        }
    }

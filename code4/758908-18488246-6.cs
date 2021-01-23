    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        [System.STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using (var form = new Form())
            using (var grid = new PropertyGrid())
            {
                grid.Dock = DockStyle.Fill;
                var obj = new DefaultValueTestClass
                {   // TODO - try with other numbers to
                    // see bold / not bold
                    Foo = 10000
                };
                // note in the grid the value is shown not-bold; that is
                // because System.ComponentModel is saying
                // "this property doesn't need to be serialized"
                // - or to show it more explicitly:
                var prop = TypeDescriptor.GetProperties(obj)["Foo"];
                bool shouldSerialize = prop.ShouldSerializeValue(obj);
                // ^^^ false, because of the DefaultValueAttribute
                form.Text = shouldSerialize.ToString(); // win title
    
                grid.SelectedObject = obj;
                form.Controls.Add(grid);
                Application.Run(form);            
            }
        }
    }
    
    public class DefaultValueTestClass
    {
        [System.ComponentModel.DefaultValue(10000)]
        public int Foo { get; set; }
    }

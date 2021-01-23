    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            PropertyMapper.Map(txtBox1, textBox2, 
                new[] { "width", "font", "forecolor", "backcolor", "text" });
        }
    }
    public static class PropertyMapper
    {
        public static void Map(Control source, Control target, params string[] properties)
        {
            properties = properties.Select(p => p.ToLowerInvariant()).ToArray();
            foreach (var prop in source.GetType().GetProperties()
                .Where(p => properties.Contains(p.Name.ToLowerInvariant()))
                    .Where(prop => prop.CanWrite))
            {
                prop.SetValue(target, prop.GetValue(source));
            }
        }
    }

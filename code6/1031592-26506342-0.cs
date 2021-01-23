    public partial class Form1 : Form
    {
        ComboBox[] cbs;
        public Form1()
        {
            InitializeComponent();
            cbs = getControls<ComboBox>(this).ToArray();
            foreach (var cb in cbs) MessageBox.Show(cb.Name);
        }
        IEnumerable<T> getControls<T>(Control top) where T : Control
        {
            var result = new List<T>();
            foreach (Control c in top.Controls) {
                if (c is T)
                {
                    result.Add((T)c);
                }
                result.AddRange(getControls<T>(c));
            }
            return result;
        }
    }

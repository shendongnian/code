    public class GUIHelper
    {
        public static GUIHelper _instance = new GUIHelper();
        public static GUIHelper Instance { get { return _instance; }}
        public string Environment { get; set; }
    }
    public class Form2
    {
        public TextBox TextBox = new TextBox();
        public Form2()
        {
            TextBox.Text = GUIHelper.Instance.Environment;
        }
    }

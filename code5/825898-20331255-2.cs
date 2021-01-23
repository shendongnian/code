    public static class FormExtensions
    {
        public static void UpdateTheme(this Form form, ITheme theme)
        {
            form.Background = theme.BackgroundColor;
            foreach(Button b in form.Controls)
            {
                if(b != null)
                    b.Background = theme.ButtonBackgroundColor;
            }
        
        }
    }
    public class SaveFrame : Form
    {
        public SaveFrame()
        {
            InitializeComponents();
        }
        public Form_OnLoad()
        {
            this.UpdateTheme(Settings.Theme);
        }
    }
    public class MainFrame :Form
    {
        public MainFrame()
        {
            InitializeComponents();
        }
        public Form_OnLoad()
        {
            this.UpdateTheme(Settings.Theme);
        }
    }

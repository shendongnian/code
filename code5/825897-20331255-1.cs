    public class SaveFrame : Frame
    {
        public SaveFrame()
        {
            InitializeComponents();
        }
        public Form_OnLoad()
        {
            var theme = Settings.Theme;
            
            this.Background = theme.BackgroundColor;
            foreach(Button b in this.Controls)
            {
                if(b != null)
                    b.Background = theme.ButtonBackgroundColor;
            }
        }
    
    }

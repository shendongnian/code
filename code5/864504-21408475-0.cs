    namespace WpfApplication
    {
        public enum TextLanguage
        {
            English,
            Arabic
        }
    
        public class CustomTextBox : TextBox
        {
            public TextLanguage TextLanguage { get; set; }
            
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (TextLanguage != WpfApplication.TextLanguage.English)
                {                
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        // Shift key is down
                        switch (e.Key)
                        {
                            case Key.Q:
                                AppendText("ص");
                                break;
                            // Handle Other Cases too
                        }
                    }
                    else if (Keyboard.Modifiers == ModifierKeys.None)
                    {                    
                        switch (e.Key)
                        {
                            case Key.Q:
                                AppendText("ض");
                                break;
                            // Handle Other Cases too
                        }
                    }
                    e.Handled = true;
                }
    
                base.OnKeyDown(e);
            }
        }
    }

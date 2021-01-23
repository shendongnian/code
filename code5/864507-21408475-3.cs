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
                    e.Handled = true;
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        // Shift key is down
                        switch (e.Key)
                        {
                            case Key.Q:
                                AddChars("ص");
                                break;
                            // Handle Other Cases too
                            default:
                                e.Handled = false;
                                break;
                        }
                    }
                    else if (Keyboard.Modifiers == ModifierKeys.None)
                    {
                        switch (e.Key)
                        {
                            case Key.Q:
                                AddChars("ض");
                                break;
                            // Handle Other Cases too
                            default:
                                e.Handled = false;
                                break;
                        }
                    }
                }
                base.OnKeyDown(e);
            }
            
            void AddChars(string str)
            {
                if (SelectedText.Length == 0)
                    AppendText(str);
                else
                    SelectedText = str;
    
                this.SelectionLength = 0;
                this.CaretIndex = Text.Length;
    
            }
        }
    }

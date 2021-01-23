    namespace WpfApplication
    {
        public class MyTextBox : TextBox
        {
            Dictionary<string, string> myDict = new Dictionary<string, string>
            {
                {"A", "B"},
                {"N", "M"},
                {"Y", "S"},            
            };
    
            protected override void OnTextInput(TextCompositionEventArgs e)
            {
                string str;
                if (myDict.TryGetValue(e.Text, out str))
                {
                    e.Handled = true;
                    if (SelectionLength == 0)
                        Text = Text.Insert(CaretIndex, str)
                    else
                    {
                        SelectedText = str;
                        SelectionLength = 0;
                    }
    
                    CaretIndex += Text.Length;
                }
    
                base.OnTextInput(e);
            }
        }
    }

     private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            var textbox = e.OriginalSource as TextBox;
            if (textbox != null && (e.Key == Key.Add || e.Key == Key.Subtract))
            {
                string signToInsert = e.Key == Key.Add ? "+" : "-";
                if (textbox.SelectionLength == 0)
                {
                    int caretPosition = textbox.CaretIndex;
                    textbox.Text = textbox.Text.Insert(caretPosition, signToInsert);
                    textbox.CaretIndex = caretPosition + 1;
                }
                else
                {
                    int selectionStart = textbox.SelectionStart;
                    int selectionLength = textbox.SelectionLength;
                    string newText = "";
                    newText += textbox.Text.Substring(0, selectionStart);
                    newText += signToInsert;
                    newText += textbox.Text.Substring(selectionStart + selectionLength);
                    textbox.Text = newText;
                    textbox.CaretIndex = selectionStart + 1;
                }
                e.Handled = true;
            }
        }

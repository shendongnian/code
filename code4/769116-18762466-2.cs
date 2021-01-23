        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String search = this.content.Text;
            TextPointer text = doc.ContentStart;
            while (true)
            {
                TextPointer next = text.GetNextContextPosition(LogicalDirection.Forward);
                if (next == null)
                {
                    break;
                }
                TextRange txt = new TextRange(text, next);
                int indx = txt.Text.IndexOf(search);
                if (indx > 0)
                {
                    TextPointer sta = text.GetPositionAtOffset(indx);
                    TextPointer end = text.GetPositionAtOffset(indx + search.Length);
                    TextRange textR = new TextRange(sta, end);
                    textR.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                }
                text = next;
            }
        }

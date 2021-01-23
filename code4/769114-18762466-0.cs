        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String search = this.content.Text;
            TextRange content = new TextRange(doc.ContentStart, doc.ContentEnd);
            var text = doc.ContentStart;
            while (true)
            {
                var next = text.GetNextContextPosition(LogicalDirection.Forward);
                if (next == null)
                {
                    break;
                }
                TextRange txt = new TextRange(text, next);
                int indx = txt.Text.IndexOf(search);
                if (indx > 0)
                {
                    var sta = text.GetPositionAtOffset(indx);
                    var end = text.GetPositionAtOffset(indx + search.Length);
                    var textR = new TextRange(sta, end);
                    textR.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                }
                text = next;
            }
        }

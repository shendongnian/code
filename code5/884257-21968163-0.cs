        public void SelectLine(int line)
        {
            int c = 0;
            TextRange r;
            foreach (var item in editor.Document.Blocks)
            {
                if (line == c)
                {
                    r = new TextRange(item.ContentStart, item.ContentEnd);
                    if (r.Text.Trim().Equals(""))
                    {
                        continue;
                    }
                    r.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Red);
                    r.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.White);
                    return;
                }
                c++;
            }
        }

            //code for adding tabItems to your tabControl            
            //when you open a file, string[] richtextBoxLines are the lines
            public TabItem TItem(string HeaderText, string[] richtextBoxLines)
            {
                TabItem t = new TabItem();
                t.Header = HeaderText;
                RichTextBox r = new RichTextBox();
                
                foreach(string s in richtextBoxLines)
                {
                    r.Selection.Text += s;
                }
                t.Content = r;
                return t;
            }
            //when you just add a tab
            public TabItem TItem(string HeaderText)
            {
                TabItem t = new TabItem();
                t.Header = HeaderText;
                RichTextBox r = new RichTextBox();
                t.Content = r;
                return t;
            }

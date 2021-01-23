            // out at CLASS/FORM level:
            private List<Control> MyControls = new List<Control>();
            // ... some method ...
                for (int i = 0; i <= rowCount - 1; i++)
                {
                    LinkLabel Linklabel = new LinkLabel();
                    MyControls.Add(Linklabel);
                    // ... rest of your code ...
                    Label label1 = new Label();
                    MyControls.Add(label1);
                    // ... rest of your code ...
                    Label label3 = new Label();
                    MyControls.Add(label3);
                    // ... rest of your code ...
                }

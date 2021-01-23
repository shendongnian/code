    private List<TextEdit> SelectTextBoxes = new List<TextEdit>();
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SelectTextBoxes = new List<TextEdit>() 
            { 
                textEdit1,textEdit3, textEdit4, textEdit2
            };
            SelectTextBoxes = SelectTextBoxes.OrderBy(x => x.TabIndex).ToList();
        }
        protected override void OnKeyDown(KeyEventArgs args)
        {
            if ((args.Modifiers == Keys.Shift) && (args.KeyCode == Keys.Tab))
            {
                interceptTabKey = !interceptTabKey;
            }
            base.OnKeyDown(args);
        }
        private bool interceptTabKey = true;
        protected override bool ProcessTabKey(bool forward)
        {
            TextEdit tb = (TextEdit)this.ActiveControl.Parent;
            // We can intercept/process the [Keys.Tab] via this method.
            if (interceptTabKey)
            {
                if (forward)            // [Keys.Shift] was not used
                {
                    if (SelectTextBoxes.Contains(tb) && tb.Text.Length > 0)
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else                   // [Keys.Shift] was used
                {
                    int currentIndex = SelectTextBoxes.IndexOf(tb);
                    var control = SelectTextBoxes[currentIndex == 0 ? SelectTextBoxes.Count - 1 : currentIndex - 1];
                    control.Select();
                }
                // [return true;]  -- To indicate that a control is selected.
                return true;
            }
            // Do this normally when not intercepted
            return base.ProcessTabKey(forward);
        }

        public TransparentDataGridView()
        {
            this.SelectionChanged += TransparentDataGridView_SelectionChanged;
        }
        void TransparentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelection();
        }

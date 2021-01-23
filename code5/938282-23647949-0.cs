    private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
    {
        Control target = new Control();
        target.Parent = sender as Control;
            if (target != null)
            {
                int targetIndex = FindCSTIndex(target.Parent);
                if (targetIndex != -1)
                {
                    string cst_ctrl = typeof(CustomControl).FullName;
                    if (e.Data.GetDataPresent(cst_ctrl))
                    {
                        Button source = new Button();
                        source.Parent = e.Data.GetData(cst_ctrl) as CustomControl;
                        if (targetIndex != -1)
                            this.flowLayoutPanel1.Controls.SetChildIndex(source.Parent, targetIndex);
                    }
                }
            }
        }

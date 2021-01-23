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
       
        private int FindCSTIndex(Control cst_ctr)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {    
                CustomControl target = this.flowLayoutPanel1.Controls[i] as CustomControl;
                if (cst_ctr.Parent == target)
                    return i;
            }
            return -1;
        }
        private void OnCstMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control cst = sender as Control;
                cst.DoDragDrop(cst.Parent, DragDropEffects.Move);
            }
        }

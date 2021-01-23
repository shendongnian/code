    t.Controls.Add(T2);
    t.Controls.Add(T);
    t.Controls.SetChildIndex(T, 1);
    t.Controls.SetChildIndex(T2, 0);
    t.PerformLayout();  // needed after SetChildIndex!
    T2.Dock = DockStyle.Left;    
    T.Dock = DockStyle.Left;

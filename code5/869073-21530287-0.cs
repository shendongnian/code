    public void ApplyToAllControls(Control node, Action<Control> lambda)
    {
       lambda(node);
       foreach(Control c in node.Controls)
       {
           ApplyToAllControls(c, lambda);
       }
    }

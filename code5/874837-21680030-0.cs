    public static void RemoveFromParent(this Control control)
    {
        if (control == null)
           throw new ArgumentNullException();
 
        if (control.Parent == null)
            return;
        control.Parent.Controls.Remove(control);
    }

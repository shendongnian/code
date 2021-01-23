    internal sealed override void OnAttach(DependencyObject d, DependencyProperty dp)
    {
        if (d == null)
            throw new ArgumentNullException("d");
        if (dp == null)
            throw new ArgumentNullException("dp");
 
        Attach(d, dp);
    }
    internal void Attach(DependencyObject target, DependencyProperty dp)
    {
        // make sure we're on the right thread to access the target
        if (target != null)
        {
            target.VerifyAccess();
        }
 
        IsAttaching = true;
        AttachOverride(target, dp);
        IsAttaching = false;
    }

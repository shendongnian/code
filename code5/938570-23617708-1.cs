    protected override void OnVisibilityChanged()
    {
        if (_anchorable != null && _anchorable.Root != null)
        {
            if (_visibilityReentrantFlag.CanEnter)
            {
                using (_visibilityReentrantFlag.Enter())
                {
                    if (Visibility == System.Windows.Visibility.Hidden)
                        _anchorable.Hide(false);
                    else if (Visibility == System.Windows.Visibility.Visible)
                        _anchorable.Show();
                }
            }
        }
 
        base.OnVisibilityChanged();
    }

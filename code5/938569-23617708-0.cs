    // LayoutItem class.
    protected virtual void OnVisibilityChanged()
    {
        if (LayoutElement != null &&
            Visibility == System.Windows.Visibility.Collapsed)
            LayoutElement.Close();
    }

    public IList<DependencyProperty> GetAttachedProperties(DependencyObject obj)
    {
        List<DependencyProperty> attached = new List<DependencyProperty>();
    
        foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(obj,
            new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
        {
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(pd);
    
            if (dpd != null && dpd.IsAttached)
            {
                attached.Add(dpd.DependencyProperty);
            }
        }
    
        return attached;
    }

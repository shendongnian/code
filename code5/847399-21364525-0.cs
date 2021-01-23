    ...
    RibbonContextualTabGroupItemsControl _ribbonContextualTabGroupItemsControl;
    ...  
    
    public override void OnApplyTemplate()  
    {  
        base.OnApplyTemplate();  
        Ribbon ribbon = this.ribbon;  
        ribbon.ApplyTemplate();  
        this._ribbonContextualTabGroupItemsControl = ribbon.Template.FindName("PART_ContextualTabGroupItemsControl", ribbon) as RibbonContextualTabGroupItemsControl;  
    }  
    ...  
    void toggleRibbonContextualGroupVisibility()  
    {  
        if(this.ribbonContextualGroup.Visibility == Visibility.Collapsed)  
        {
            if (this.ribbon.IsMinimized)  
            {  
                this.ribbon.IsMinimized = false;  
                this.ribbonContextualGroup.Visibility = Visibility.Visible;  
                this._ribbonContextualTabGroupItemsControl.UpdateLayout();  
                this.ribbon.IsMinimized = true;  
            }  
            else  
            {  
                this.ribbonContextualGroup.Visibility = Visibility.Visible;  
            }  
        }
        else  
        {  
            this.ribbonContextualGroup.Visibility = Visibility.Collapsed;
        }
    }  
    ...  

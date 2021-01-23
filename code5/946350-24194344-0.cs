    protected override Visual GetVisualChild(int index)
    {
        if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) 
        {
            return; //do not perform custom logic during design time
        }
    
        switch (index)
        {
            case 0:
                if (!textLayerReady)
                {
                    using (var textContext = textLayer.Open())
                        RenderTextLayer(textContext);
                }
                return textVisual;
            default:
                throw new ArgumentOutOfRangeException("index");
        }
    }

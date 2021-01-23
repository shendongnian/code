    private readonly DrawingVisual textLayer = new DrawingVisual();
    bool textLayerReady;
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
                    using (var textContext = textLayer.RenderOpen())
                        RenderTextLayer(textContext);
                }
                return textLayer;
            default:
                throw new ArgumentOutOfRangeException("index");
        }
    }

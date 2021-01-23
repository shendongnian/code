    public void ActionRunnerThreadFunc()
    {
        _drawQueue.Enqueue(new SpaceShipRenderer(x, y));
    }
    
    public void UIThreadFunc()
    {
        IItemRender item;
        if (_drawQueue.TryDequeue(out item))
            item.Draw(drawContext);
    }

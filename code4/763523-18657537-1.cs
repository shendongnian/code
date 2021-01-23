    protected void AddChild(IContextConsumer child) {
        Children.Add(child);
        child.Context = this.Context;
    }
    protected void OnContextChanged() {
        foreach (var child in Children) child.Context = this.Context;
    }

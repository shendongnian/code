    [Test]
    public void Repro()
    {
        var args = new DependencyPropertyChangedEventArgs(UIElement.IsEnabledProperty, false, true);
        Assert.Throws<InvalidCastException>(() => args.Equals(1));
    }

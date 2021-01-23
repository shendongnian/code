    public class Bar
    {
        public void Foo(object sender, EventArgs args)
        {
        }
    }
    
    [Test]
    public void ActionIsNotGCedBeforeTarget()
    {
        Bar bar = new Bar();
        Action<object, EventArgs> action = bar.Foo;
        WeakReference weakRef = new WeakReference(action);
        action = null;
        GC.Collect();
    
        Assert.IsTrue(weakRef.IsAlive); // Will be false
    }

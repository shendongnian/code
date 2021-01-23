    var classB = new ClassB();  // presumably in your code in A somewhere
    classB.MyEvent += new EventHandler(this.HandleEventFromB);
    public void HandleEventFromB(object sneder, EventArgs args)
    {
        ClassA.StaticMethod();
    }

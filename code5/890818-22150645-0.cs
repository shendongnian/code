    var classB = new ClassB();  // presumably in your code in A somewhere
    classB.MyEvent += new EventHandler(this.HandleEventFromB);
    public void HandleEventFromB(object sneder, EventAgrs args)
    {
        ClassA.StaticMethod();
    }

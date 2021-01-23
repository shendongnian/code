    public void SomeFunc(System.Drawing.Rectangle aRectangle)
    {
        // Only the local SomeFunc copy of aRectangle is changed:
        aRectangle.X = 99;
        // Passes - the changes last for the scope of the copied variable
        Assert.AreEqual(99, aRectangle.X);
    }  // The copy aRectangle will be lost when the stack is popped.
    // Which when called:
    var myRectangle = new System.Drawing.Rectangle(10, 10, 20, 20);
    // A copy of `myRectangle` is passed on the stack
    SomeFunc(myRectangle);
    // Test passes - the caller's struct has NOT been modified
    Assert.AreEqual(10, myRectangle.X);

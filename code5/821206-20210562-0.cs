    [Java.Interop.Export("myClickHandler")] // The value found in android:onClick attribute.
    public void myClickHandler(View v) // Does not need to match value in above attribute.
    {
        Console.WriteLine ((v as Button).Text);
    }

    while(...)
    {
       ... bunch of other code
       buildTask(buffer[currentIndex]);
       buffer[currentIndex] = new object();
       ... bunch of other code
    }
    // Within this method, all references to detachedBuffer object will remain pointing to the same
    // memory location no matter whether the variable passed in is reassigned.
    public void buildTask(object detachedBuffer)
    {
        task.factory.starnew(()=>{
            writeOutObject(detachedBuffer);
        };
    }

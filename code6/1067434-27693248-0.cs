    public delegate void PropertySetter(float newVal);
    public void Animate(PropertySetter setter, float time, float valToSet, Action callback=null)
    {
       // the implementation-specific code for interpolating values will go here.  and call "callback" when complete, if it's non-null.
    }
    

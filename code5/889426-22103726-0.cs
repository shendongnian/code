    private GestureDetector.OnGestureListener mFlingRemoveListener = new SimpleOnGestureListenerAnonymousInnerClassHelper();
    
    private class SimpleOnGestureListenerAnonymousInnerClassHelper : GestureDetector.SimpleOnGestureListener
    {
    	public override bool onFling()
    	{
    		return false;
    	}
    }

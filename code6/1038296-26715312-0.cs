    public static void Try(Action action, int tryCount = 3) {
    	if (action == null)
    		throw new ArgumentNullException("action");
    	if (tryCount <= 0)
    		throw new ArgumentException("tryCount");
    
    	Exception lastException = null;
    	bool lastTryFailed = true;
    	int timesRemaining = tryCount;
    	while (timesRemaining > 0 && lastTryFailed) {
    		lastTryFailed = false;
    		try {
    			action();
    		} catch (Exception ex) {
    			if (ex != null && lastException != null &&
    				!(
    					ex.GetType() == lastException.GetType() ||
    					ex.GetType().IsSubclassOf(lastException.GetType()) ||
    					lastException.GetType().IsSubclassOf(ex.GetType())
    				)
    			) {
    				throw new InvalidOperationException("Different type of exceptions occured during the multiple tried action.", ex);
    			}
    
    			// Continue
    			lastException = ex;
    			lastTryFailed = true;
    		}
    		timesRemaining--;
    	}
    	if (lastTryFailed) {
    		throw new InvalidOperationException("Action failed multiple times.", lastException);
    	}
    }

    public bool IsDebuggingEnabled {
    	get {
    		// Returns false when:
    		// - Deployment mode is set to retail (override all other settings)
    		// - ScriptMode is set to Auto or Inherit, and debugging it not enabled in web.config
    		// - ScriptMode is set to Release
    
    		if (DeploymentSectionRetail) {
    			return false;
    		}
    		if (ScriptMode == ScriptMode.Auto || ScriptMode == ScriptMode.Inherit) {
    			return AppLevelCompilationSection.Debug;
    		}
    		return (ScriptMode == ScriptMode.Debug);
    	}
    }

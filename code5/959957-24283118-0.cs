    static public void CreateForm() {
    	Action action = () => { f2.Show(); };
    	if (f2.InvokeRequired) {
    		f2.Invoke(action);
    	} else {
    		action();
    	}
    }

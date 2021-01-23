    Editor[] editors =  ActiveEditorTracker.sharedTracker.activeEditors;
		Editor e0 = editors[0];
		Editor e1 = editors[1];
		Editor e2 = editors[2];
		Editor[] test = {e0, e1, e2};
		Debug.Log(test.GetType());
		Debug.Log(typeof(Editor).IsAssignableFrom(test[0].GetType()));
		Debug.Log(typeof(Editor).IsAssignableFrom(test.GetType().GetElementType()));

    	EnvDTE.TextSelection textSelection = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
		if (textSelection == null)
			return;
		EnvDTE.CodeClass codeClass = textSelection.ActivePoint.CodeElement[vsCMElement.vsCMElementClass] as EnvDTE.CodeClass;
		if (codeClass == null)
			return;
		string properties = "";
		foreach (CodeElement elem in codeClass.Members)
		{
			if (elem.Kind == vsCMElement.vsCMElementProperty)
				properties += elem.Name + System.Environment.NewLine;
		}
		System.Windows.Clipboard.SetText(properties);

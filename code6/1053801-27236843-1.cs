    private void pasteButton_Click(object sender, RoutedEventArgs e)
    {
		var dataObject = Clipboard.GetDataObject();
		if (dataObject != null) {
            Exported incomingObject;
			if (dataObject.GetDataPresent(typeof(Exported))) {
				incomingObject = dataObject.GetData(typeof(Exported));
			} else {
                var obj = dataObject.GetData(typeof(Object));
                incomingObject = obj as Exported;
			}
            if (incomingObject != null) {
              // what you want to do with it can go here
            }
		}
    }

    private void pasteButton_Click(object sender, RoutedEventArgs e)
    {
		var dataObject = Clipboard.GetDataObject();
		if (dataObject != null) {
			if (dataObject.GetDataPresent(typeof(Exported))) {
				var incomingObject = dataObject.GetData(typeof(Exported));
			} else {
				var dataType = dataObject.GetType();
				Console.WriteLine("Object Type is {0}", dataType);
			}
		}
    }

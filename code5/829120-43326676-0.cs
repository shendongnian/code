	void IOverlayWindow.DragEnter(IDropArea area)
	{
		...
		switch (area.Type)
		{
			...
			case DropAreaType.DocumentPane:
			default:
				{
					...
					else
					{
						areaElement = _gridDocumentPaneDropTargets;
						_documentPaneDropTargetLeft.Visibility = Visibility.Hidden;
						_documentPaneDropTargetRight.Visibility = Visibility.Hidden;
						_documentPaneDropTargetTop.Visibility = Visibility.Hidden;
						_documentPaneDropTargetBottom.Visibility = Visibility.Hidden;
						/* ... */
					}
				}
			break;
		}
		...
	}

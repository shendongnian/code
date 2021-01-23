	private bool _isInvetoryOpen = false;
	void OnGUI () {
		GUI.Box (new Rect (10, 10, 100, 200), "Menu");
		// Toggle _isInventoryOpen flag on Inventory button click.
		if (GUI.Button (new Rect (20, 50, 75, 20), "Inventory")) {
			_isInvetoryOpen = !_isInvetoryOpen;
		}
		// If _isInventoryOpen is true, draw the invetory rectangle.
		if (_isInvetoryOpen) {
			GUI.Box (new Rect (150, 10, 300, 200), "Inventory");
		}
	}

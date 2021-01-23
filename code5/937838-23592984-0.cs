	public class IItemDatabase : MonoBehaviour
	{
		public static event Action onClicked; // The event for when the button has been clicked
		
		private bool showInventory = false;
		protected virtual void OnGUI()
		{
			// I removed your other code to simplify the example
			if (GUI.Button("Open Inventory"))
			{
				// toggle the status
				showInventory = !showInventory
			}
			if (showInventory && onClicked != null)
			{
				onClicked();
			}
		}
	}

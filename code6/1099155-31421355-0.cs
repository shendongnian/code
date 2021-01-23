    public class ActionTrayView : View
	{
		public static BindableProperty TrayTypeProperty = BindableProperty.Create((ActionTrayView v) => v.TrayType, ActionTrayType.Draggable);
		public ActionTrayType TrayType
		{
			get 
			{
				return (ActionTrayType)GetValue(TrayTypeProperty);
			}
			set
			{
				SetValue(TrayTypeProperty, value);
			}
		}
		public static BindableProperty OrientationProperty = BindableProperty.Create((ActionTrayView v) => v.Orientation, ActionTrayOrientation.Bottom);
		public ActionTrayOrientation Orientation
		{
			get
			{
				return (ActionTrayOrientation)GetValue(OrientationProperty);
			}
			set
			{
				SetValue(OrientationProperty, value);
			}
		}
	}
	public enum ActionTrayType
	{
		/// <summary>
		/// When the user taps the ActionTray's DragTab, the tray will snap between its openedPostion and closedPostion. 
		/// If the tray is open and the user taps anywhere within its content area, the tray will automatically close.
		/// </summary>
		AutoClosingPopup,
		/// <summary>
		/// The ActionTray can be dragged by its dragTab between the specified openedPosition and closedPosition
		/// </summary>
		Draggable,
		/// <summary>
		/// When the user taps the ActionTray's DragTab, the tray will snap between its openedPosition and closedPosition
		/// </summary>
		Popup
	}
	public enum ActionTrayOrientation
	{
		/// <summary>
		/// The ActionTray is at the bottom of the screen
		/// </summary>
		Bottom,
		/// <summary>
		/// The ActionTray is on the left side of the screen
		/// </summary>
		Left,
		/// <summary>
		/// The ActionTray is on the ride side of the screen
		/// </summary>
		Right,
		/// <summary>
		/// The ActionTray is at the top of the screen
		/// </summary>
		Top
	}

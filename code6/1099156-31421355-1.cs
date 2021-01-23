     using System.Drawing;
     using Xamarin.Forms.Platform.iOS;
     using Xamarin.Forms;
     using System.ComponentModel;
     using **YourXamarinFormsPCLProjectReference**;
     using **YourXamarinFormsPCLProjectReference**.iOS;
     using UIKit;
     using System;
     using System.Collections.Generic;
     using CoreGraphics;
     using Appracatappra.ActionComponents.ActionTray;
     [assembly: ExportRenderer(typeof(ActionTrayView), typeof(ActionTrayRendereriOS))]
     namespace **YourXamarinFormsPCLProjectReference**.iOS
     {
	  public class ActionTrayRendereriOS : ViewRenderer<ActionTrayView, UIActionTray> 
	  {
		protected override void OnElementChanged (ElementChangedEventArgs<ActionTrayView> e)
		{
			base.OnElementChanged(e);
			if(e.OldElement == null) 
			{
				SetNativeControl(new UIActionTray());
				Control.trayType = GetTrayType(e.NewElement.TrayType);
				Control.orientation = GetTrayOrientation(e.NewElement.Orientation);
			}
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews();
			Control.CloseTray(false);
		}
		private UIActionTrayType GetTrayType(ActionTrayType trayType)
		{
			switch(trayType) 
			{
				case ActionTrayType.AutoClosingPopup:
				{
					return UIActionTrayType.AutoClosingPopup;
				}
				case ActionTrayType.Draggable:
				{
					return UIActionTrayType.Draggable;
				}
				case ActionTrayType.Popup:
				{
					return UIActionTrayType.Popup;
				}
				default:
				{
					return UIActionTrayType.Draggable;
				}
			}
		}
		private UIActionTrayOrientation GetTrayOrientation(ActionTrayOrientation orientation)
		{
			switch (orientation) 
			{
				case ActionTrayOrientation.Bottom:
				{
					return UIActionTrayOrientation.Bottom;
				}
				case ActionTrayOrientation.Left:
				{
					return UIActionTrayOrientation.Left;
				}
				case ActionTrayOrientation.Right:
				{
					return UIActionTrayOrientation.Right;
				}
				case ActionTrayOrientation.Top:	
				{
					return UIActionTrayOrientation.Top;
				}
				default:
				{
					return UIActionTrayOrientation.Bottom;
				}
			}
		}
	}

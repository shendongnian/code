    public class MvxSwTableViewCell
        : SWTableViewCell, IMvxBindable
    {
	
	    // Rest of class omitted
	
	    public static UIButton GetUtilityButtonWithColor(UIColor color, string title)
        {
        	var button = new UIButton(UIButtonType.Custom);
        	button.BackgroundColor = color;
        	button.SetTitle(title, UIControlState.Normal);
        	button.SetTitleColor(UIColor.White, UIControlState.Normal);
        	button.TitleLabel.AdjustsFontSizeToFitWidth = true;
        
        	return button;
        }
	}

    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace DepPropTest
    {
	    /// <summary>
	    /// Description of CreateRuleItemView.
	    /// </summary>
	    public class CreateRuleItemView : ContentControl
	    {
		    public CreateRuleItemView()
		    {
		    }
		
		    public static readonly DependencyProperty ShowEditTablePopupProperty = 
			    DependencyProperty.Register("ShowEditTablePopup", typeof (bool), typeof (CreateRuleItemView), new PropertyMetadata());
		
		    public bool ShowEditTablePopup
		    {
		    	get { return (bool) GetValue(ShowEditTablePopupProperty); }
		    	set { SetValue(ShowEditTablePopupProperty, value); }
		    }
		                                                                                                   
	    }
    }

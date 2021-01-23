    using System;
    using Xamarin.Forms;
    #if __ANDROID__
    using Android.App;
    #endif
    
    namespace SEEForgeX.Helpers
    {
    	public class BaseContentPage : ContentPage
    	{
    		#region PRIVATE VARIABLES
    #if __ANDROID__
    		ProgressDialog p = null;
    #endif
    		#endregion
    
    		#region PROPERTIES
            public bool IsShowing { get; set; }
    		public bool LoadingViewFlag {
    			get {
    				return (bool)GetValue (LoadingProperty);
    			}
    			set {
    				SetValue (LoadingProperty, value);
    
    #if __ANDROID__
    				if (value == true)
    				{
    					p = new ProgressDialog(Forms.Context);
    					p.SetMessage("Loading...");
                        p.SetCancelable(false);
    					p.Show();
                        IsShowing = true;
    				}
    				else
    				{
    					if (p != null)
    					{
    						p.Dismiss();
    						p = null;
                            IsShowing = false;
    					}
    				}
    #endif
                }
    		}
    
    		public static readonly BindableProperty LoadingProperty = 
    			BindableProperty.Create ((BaseContentPage w) => w.LoadingViewFlag, false);
    		#endregion
    
    		public BaseContentPage ()
    		{
    		}
    	}
    }

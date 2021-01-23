    public override void Show (MvxViewModelRequest request)
    		{
    			var fragmentHost = Activity as IMvxFragmentHost;
    			if (fragmentHost != null) {
    				var bundle = new Bundle ();
    				var serializedRequest = Serializer.Serializer.SerializeObject (request);
    				bundle.PutString (ViewModelRequestBundleKey, serializedRequest);
    				fragmentHost.Show (request, bundle);
    			}
    			else
    			{
    				var bundle = new Bundle();
    				var serializedRequest = Serializer.Serializer.SerializeObject(request);
    				bundle.PutString(ViewModelRequestBundleKey, serializedRequest);
    
    				var intentFor = new Intent (Activity.ApplicationContext, typeof(MainActivity));
    				intentFor.PutExtra ("request", bundle);
    				base.Show(intentFor);
    			}
    		}

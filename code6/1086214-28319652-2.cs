    protected override void OnCreate(Bundle bundle)
    		{
    			base.OnCreate(bundle);
    
    			Bundle request = Intent.GetBundleExtra ("request");
    			if (request != null) {
    				var deserializedRequest = Serializer.Serializer.DeserializeObject<MvxViewModelRequest>(request.GetString(CustomFragmentsPresenter.ViewModelRequestBundleKey));
    				Show (deserializedRequest, request);
    			}
    		}

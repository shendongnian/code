    public class CustomAndroidPresenter : MvxAndroidViewPresenter 
        {
            public override void Show(MvxViewModelRequest request)
            {
                if (request != null && request.PresentationValues != null)
                {
                    if (request.PresentationValues.ContainsKey("MyCustomFlag"))
                    {
                        // Get intent from request and set flags to clear backstack.
                        var intent = base.CreateIntentForRequest(request);
                        intent.SetFlags(ActivityFlags.ClearTask | ActivityFlags.NewTask);
    
                        base.Show(intent);
                        return;
                    }
                }
    
                base.Show(request);
            }
        }

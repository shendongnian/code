    public partial class TestViewController : UIViewController
    {
        public async Task LoginButton_click(UIButton sender)
        {
            hud = new MTMBProgressHUD(View)
            {
                LabelText = "Waiting...",
                RemoveFromSuperViewOnHide = true,
            };
    
            View.AddSubview(hud);
            hud.Show(animated: true);
    
    
            APIClient ApiClient = new APIClient();
            TestAPI cd = new TestAPI(ApiClient);
            var apiResponse = await cd.ExecuteAsync<YourType>();
    
            hud.Hide(animated: true);
    
        }
    }

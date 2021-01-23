     // when Navigating:
     if (PhoneApplicationService.Current.State.ContainsKey("data")) PhoneApplicationService.Current.State["data"] = basket;
     lse PhoneApplicationService.Current.State.Add("data", basket);
     // in constructor of next page, or OnNavigatedTo event:
     Basket passedOne = PhoneApplicationService.Current.State["data"] as Basket;

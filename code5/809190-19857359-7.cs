    var mytask = methodname();
        mytask.ContinueWith(c =>
        {
             var jsonResponse = JObject.Parse(c.Result);
             // or JArray
             var jsonResponseArray = JArray.Parse(c.Result);
             foreach (var item in jsonResponseArray)
             {
                  var id = item.SelectToken("id").ToString();
                  // and so on...
             }
             var selectSomething = jsonResponse.SelectToken("somethinghere");
             Deployment.Current.Dispatcher.BeginInvoke(() =>
             {
                     // do your ui tasks, navigate etc...
             });
        });

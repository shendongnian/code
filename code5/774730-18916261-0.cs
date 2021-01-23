        public class State
        {
            public HttpWebRequest WebRequest { get; set; }
            public Func<Response> ResponseCallBack;
        }
        void sampleRequest(Func<Response> responseCallBack)
        {
            HttpWebRequest httpLoginRequest = (HttpWebRequest)WebRequest.Create(new Uri(DisplayMessage.Authentication_URL));
            //httpLoginRequest.Method = DisplayMessage.Get_Method;
            //Parameters = new Dictionary<string, string>();
            httpLoginRequest.BeginGetResponse(new AsyncCallback(GetLoginCallback), 
                new State(){WebRequest = httpLoginRequest,
                            ResponseCallBack = responseCallBack
                });
        }
        
 
        private void GetLoginCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                State state= (State)asynchronousResult.AsyncState;
                HttpWebResponse httpresponse = (HttpWebResponse)state.WebRequest.EndGetResponse(asynchronousResult);
                  ...
                 //Dispatch request back to ui thread
                  Deployment.Current.Dispatcher.BeginInvoke(() =>
                  {
                       state.ResponseCallBack(myResponse);
                   });
            }
            catch(WebException ex)
            {
            }
        }
     

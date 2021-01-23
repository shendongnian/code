    public class MyDerived: WebView
    {
    ...
    
        public const string COM_COMMAND_INIT = "http://mypresetcommand/?";
        protected override void OnResourceRequestStarting(WebKit.WebFrame web_frame, WebKit.WebResource web_resource, WebKit.NetworkRequest request, WebKit.NetworkResponse response)
        {
            // check if this is a command
            if (request.Uri.ToLower().StartsWith(COM_COMMAND_INIT))
            {
                // this is a com command. Responding with responce.
                string cmnd = web_resource.Uri.Substring(COM_COMMAND_INIT.Length);
                // HANDLE COMMAND HERE.
                return;
            }
            base.OnResourceRequestStarting(web_frame, web_resource, request, response);
        }
    }

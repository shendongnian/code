    public class CallbackObjectForJs{
        public void showMessage(string msg){//Read Note
            MessageBox.Show(msg);
        }
    }
     
    WebView webView = new WebView("http://localhost:8080");
    webView.RegisterJsObject("callbackObj", new CallbackObjectForJs());

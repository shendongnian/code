    public class CallbackObjectForJs{
        public void showMessage(string msg){
            MessageBox.Show(msg);
        }
    }
     
    WebView webView = new WebView("http://localhost:8080");
    webView.RegisterJsObject("callbackObj", new CallbackObjectForJs());

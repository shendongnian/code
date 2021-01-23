    public class MyForm : Form
    {
        WebBrowser _Webbrowser = new WebBrowser();
        TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
        public MyForm(string url)
        {
            _Webbrowser.ScriptErrorsSuppressed = true;
            this.Controls.Add(_Webbrowser);
            _Webbrowser.DocumentCompleted += (s, e) => { _tcs.TrySetResult(null); };
            _Webbrowser.Navigate(url);
        }
        public async new void Show()
        {
            await _tcs.Task;
            base.Show();
        }
    }

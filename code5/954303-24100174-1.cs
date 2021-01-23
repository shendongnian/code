    webBrowser1.ObjectForScripting = new MyForm();
    string html = "<script>external.DoSomething('test');</script>";
    webBrowser1.DocumentText = html;
---
    [ComVisible(true)]
    public class MyForm : Form
    {
        public void DoSomething(string s)
        {
            MessageBox.Show("Called from JS: " + s);
        }
    }

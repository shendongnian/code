[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
[ComVisible(true)]
public class ObjectForScriptingHelper
{
    Mainwindow mExternalWPF;
    public ObjectForScriptingHelper(Window1w)
    {
        this.mExternalWPF = w;
    }
    public void InvokeMeFromJavascript(string jsscript)
    {
        this.mExternalWPF.tbMessageFromBrowser.Text = string.Format("Message :{0}", jsscript);
    }
    
}

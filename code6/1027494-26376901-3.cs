    public class MyPage : Page
    {
         // This will be in your partial class I assume?
         private scriptLink scriptLinkControl;
         protected override void Page_Load(object sender, EventArgs e)
         {
             pbwebdata webdata = new pbwebdata();
             DoThingsWith(webdata);
             this.scriptLinkControl.pbwebdata = webdata;
         }
    }

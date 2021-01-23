    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text;
    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        ShoutItemList shoutBox;
        if (Application["ShoutBox"] == null)
        {
            shoutBox = new ShoutItemList();
            Application.Add("ShoutBox", shoutBox);
        }
        else
        {
            shoutBox = (ShoutItemList)Application["ShoutBox"];
            lblShoutBox.Text = shoutBox.Display();
        }
        if (ScriptManager1.IsInAsyncPostBack != true)
            txtUserName.Focus();
    }
    protected void btnAddShout_Click(object sender, EventArgs e)
    {
        ShoutItem shout = new ShoutItem();
        shout.UserName = txtUserName.Text;
        shout.Comment = txtShout.Text;
        shout.Timestamp = DateTime.Now;
        Application.Lock();
        ShoutItemList shoutBox = (ShoutItemList)Application["ShoutBox"];
        shoutBox.Add(shout);
        Application.UnLock();
        lblShoutBox.Text = shoutBox.Display();
        txtShout.Text = "";
        txtShout.Focus();
    }
    }
    public class ShoutItem
    {
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment { get; set; }
    }
    public class ShoutItemList
    {
    private List<ShoutItem> shoutList = new List<ShoutItem>();
    private void Purge()
    {
        DateTime purgeTime = DateTime.Now;
        purgeTime = purgeTime.AddMinutes(-3);
        int i = 0;
        while (i < shoutList.Count)
        {
            if (shoutList[i].Timestamp <= purgeTime) shoutList.RemoveAt(i);
            else i += 1;
        }
    }
    public void Add(ShoutItem shout)
    {
        Purge();
        System.Threading.Thread.Sleep(2000);
        shoutList.Insert(0, shout);
    }
    public string Display()
    {
        Purge();
        StringBuilder shoutBoxText = new StringBuilder();
        if (shoutList.Count > 0)
        {
            shoutBoxText.AppendLine("<dl>");
            foreach (ShoutItem shout in shoutList)
            {
                shoutBoxText.Append("<dt>" + shout.UserName + " (");
                shoutBoxText.Append(shout.Timestamp.ToShortTimeString() + ")</dt>");
                shoutBoxText.AppendLine("<dd>" + shout.Comment + "</dd>");
            }
            shoutBoxText.AppendLine("</dl>");
        }
        return shoutBoxText.ToString();
    }
    }

    If you want to change your time only changes when the page is refreshed than used IsPostBack Event
      <script runat="server">
       protected void Page_Load(object sender, EventArgs e)
        {
         if(!IsPostBack)
          {
           DateTime dt = DateTime.Now;
           string Day = dt.Day.ToString();
           string Month = dt.ToString("MMM");
           string Hour = dt.Hour.ToString();
           string Minute = dt.ToString("mm");
           timeNow.Text = Day + " " + Month + "   " + Hour + ":" + Minute;
          }
    }
      </script>

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

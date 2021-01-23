    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Day = dt.Day.ToString();
            string Month = dt.ToString("MMM");
            string Hour = dt.Hour.ToString();
            string Minute = dt.ToString("mm");
            string Seconds = dt.ToString("ss");
            timeNow.Text = Day + " " + Month + "   " + Hour + ":" + Minute + ":" + Seconds;
        }
    </script>

    public partial class SORGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = @"http://osw-hml3mes.novelis.biz:3020/Preheat/Downtime/History/30";
            List<SorEvent> events = JsonConvert.DeserializeObject<List<SorEvent>>(new WebClient().DownloadString(url));
            events = events.OrderByDescending(ev => ev.StartTime).ToList();
            if (!IsPostBack)
            {
                GridView1.DataSource = events;
                GridView1.DataBind();
            }
        }
    
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // get dates and call the url with those 2 dates (POST call)
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string url = @"http://osw-hml3mes.novelis.biz:3020/Preheat/Downtime/History/30";
            if(startDate != "" || endDate != "")
                url = @"http://osw-hml3mes.novelis.biz:3020/Preheat/Downtime/HistoryByDate?startDate=" +
                         startDate + "&endDate=" + endDate;
            List<SorEvent> events = JsonConvert.DeserializeObject<List<SorEvent>>(new WebClient().DownloadString(url));
            events = events.OrderByDescending(ev => ev.StartTime).ToList();
            if (IsPostBack)
            {
                GridView1.DataSource = events;
                GridView1.DataBind();
            }
            
        }
    }

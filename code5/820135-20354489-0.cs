    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Google.GData.Analytics;
    using Google.GData.Client;
    using Google.GData.Extensions;
    
    
    namespace Gongos.AnalyticsAPI
    {
    	public partial class _Default : Page
    	{
    
    		public string VisitsNumber()
    		{		
    
    			string visits = string.Empty;
    			string username = "******** --> Your email";
    			string pass = "********** --> Your password";
    			string gkey = "?key= **** --> Your APY key <--  ****";
    
    			string dataFeedUrl = "https://www.google.com/analytics/feeds/data" + gkey;
    			string accountFeedUrl = "https://www.googleapis.com/analytics/v2.4/management/accounts" + gkey;
    
    			AnalyticsService service = new AnalyticsService("WebApp");
    			service.setUserCredentials(username, pass);
    
    			DataQuery query1 = new DataQuery(dataFeedUrl);
    
    			query1.Ids = "ga:********";
    			query1.Metrics = "ga:visits";
    			query1.Sort = "ga:visits";
    
    			
    			query1.GAStartDate = new DateTime(2013, 1, 2).ToString("yyyy-MM-dd");
    			query1.GAEndDate = DateTime.Now.ToString("yyyy-MM-dd");
    			query1.StartIndex = 1;
    
    			DataFeed dataFeedVisits = service.Query(query1);
    
    			foreach (DataEntry entry in dataFeedVisits.Entries)
    			{
    				string st = entry.Title.Text;
    				string ss = entry.Metrics[0].Value;
    				visits = ss;
    			}
    
    			return visits;
    		}
    
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			if (!Page.IsPostBack)
    			{
    				Response.Write("Visits:" + this.VisitsNumber());
    			}
    		}
    
    	}
    }

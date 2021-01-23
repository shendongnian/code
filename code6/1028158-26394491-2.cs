    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Runtime.Serialization;
    using System.Web;
    using Newtonsoft.Json.Linq;
    
    
    
    namespace RESTTEST2
    {
     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
    public class Notice
    {
        public string copyright { get; set; }
        public string copyright_url { get; set; }
        public string disclaimer_url { get; set; }
        public string feedback_url { get; set; }
    }
    
    public class Header
    {
        public string refresh_message { get; set; }
        public string ID { get; set; }
        public string main_ID { get; set; }
        public string name { get; set; }
        public string state_time_zone { get; set; }
        public string time_zone { get; set; }
        public string product_name { get; set; }
        public string state { get; set; }
    }
    
    public class Datum
    {
        public int sort_order { get; set; }
        public int wmo { get; set; }
        public string name { get; set; }
        public string history_product { get; set; }
        public string local_date_time { get; set; }
        public string local_date_time_full { get; set; }
        public string aifstime_utc { get; set; }
        public double air_temp { get; set; }
        public double apparent_t { get; set; }
        public string cloud { get; set; }
        public object cloud_base_m { get; set; }
        public int cloud_oktas { get; set; }
        public string cloud_type { get; set; }
        public object cloud_type_id { get; set; }
        public double delta_t { get; set; }
        public double dewpt { get; set; }
        public object gust_kmh { get; set; }
        public object gust_kt { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public object press { get; set; }
        public object press_msl { get; set; }
        public object press_qnh { get; set; }
        public string press_tend { get; set; }
        public string rain_trace { get; set; }
        public int rel_hum { get; set; }
        public string sea_state { get; set; }
        public string swell_dir_worded { get; set; }
        public object swell_height { get; set; }
        public object swell_period { get; set; }
        public string vis_km { get; set; }
        public string weather { get; set; }
        public string wind_dir { get; set; }
        public int wind_spd_kmh { get; set; }
        public int wind_spd_kt { get; set; }
    }
    
    public class Observations
    {
        public List<Notice> notice { get; set; }
        public List<Header> header { get; set; }
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public Observations observations { get; set; }
    }
    
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "test";
            string url = "http://www.bom.gov.au/fwo/IDN60901/IDN60901.95764.json";
    
      HttpWebRequest req = WebRequest.Create(url)
                       as HttpWebRequest;
      req.Credentials = CredentialCache.DefaultCredentials;
      req.ContentType = "application/json";
    
      string result = null;
      using (HttpWebResponse resp = req.GetResponse()
                                as HttpWebResponse)
      {
      StreamReader reader =
      new StreamReader(resp.GetResponseStream());
      result = reader.ReadToEnd();
      richTextBox2.Text = result; 
    
      var bar = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(result);
      var bar2 = bar.observations.notice; // this will have the List<notice> 
      // now you can loop through the List<notice> in bar2 and do whatever you want with it's data.
      // var bar3 = result.ToString();
      richTextBox1.Text = bar2;
    
      }
    
    
    
      }
        }
    }

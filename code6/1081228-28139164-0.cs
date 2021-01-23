    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using System.Net;
    using System.IO;
    
    namespace mblog {
    	public partial class WebForm1 : System.Web.UI.Page {
    		
    		public XmlDocument HTTPGetXML(string strURL) {
    			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strURL);
    			req.Method = "GET";
    			req.Timeout = 120000;  // 2 minutes
    
    			XmlDocument xmlReturn = new XmlDocument();
    			// UGH! not set by default!
    			req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
    			// Set AllowWriteStreamBuffering to 'false'. 
    			req.AllowWriteStreamBuffering = false;
    			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
    			string msg;
    
    			try {
    				// Get the response from the server
    				StreamReader reader = new StreamReader(resp.GetResponseStream());
    				msg = reader.ReadToEnd();
    				xmlReturn.LoadXml(msg);
    			} catch (Exception e) {
    				throw new Exception("Error posting to server.", e);
    			}
    			return xmlReturn;
    		}  
    
    		protected void Page_Load(object sender, EventArgs e) {
    			try {
    				XmlDocument xmlWeather = HTTPGetXML("http://weather.yahooapis.com/forecastrss?w=2475688");
    
    				NameTable nt = new NameTable();
    				XmlNamespaceManager nsmgr;
    
    				nsmgr = new XmlNamespaceManager(nt);
    				nsmgr.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");
    
    				
    				XmlNode ndLocation = xmlWeather.SelectSingleNode("//yweather:location", nsmgr);
    				if( ndLocation != null ) {
    					string strCity = ndLocation.Attributes["city"].Value;
    				}
    
    
    			} catch (Exception ex) {
    				Response.Write( ex.Message );
    			}
    
    	
    		}
    	}
    }

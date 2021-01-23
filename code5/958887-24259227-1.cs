    //This is the webform
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.IO;
    using System.Text.RegularExpressions;
    
    
    namespace PatientImport {
    	public partial class WebForm1: System.Web.UI.Page {
    		public void Page_Load(object sender, EventArgs e) {
    			if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0)) {
    				string fn = Path.GetFileName(File1.PostedFile.FileName);
    				string SaveLocation = Server.MapPath("Data") + "\\" + fn;
    				
    				try {
    					if (fn.Substring(fn.Length - 3) == "csv" || fn.Substring(fn.Length - 3) == "CSV") {
    						File1.PostedFile.SaveAs(SaveLocation);
    						Response.Write("The file has been uploaded.");
    						
    						// Read and parse the file
    						string[] data = File.ReadAllLines(SaveLocation);
    						string pattern = "\"(?<data>.*?)\"|(^|,)(?<data>[^,\r\n]*)";
    						RegexOptions options = RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.ECMAScript;
    						
    						DataTable dt = new DataTable();
    						
    						MatchCollection matches = Regex.Matches(data[0], pattern, options);
    						
    						foreach (Match match in matches) {
    							dt.Columns.Add(match.Groups["data"], typeof(string));
    							
    							match = match.NextMatch();
    						}
    						
    						for (int i = 1; i < data.Length; i++) {
    							matches = Regex.Matches(data[i], pattern, options);
    							
    							List<string> row = new List<string>();
    							
    							foreach (Match match in matches) {
    								row.Add(match.Groups["data"]);
    								
    								match = match.NextMatch();
    							}
    							
    							dt.Rows.Add(row.ToArray());
    						}
    						
    						CSVGridView.DataSource = dt;
    						CSVGridView.DataBind();
    					} else {
    						Response.Write("Incorrect type. Choose a .csv file to upload.");
    					}
    				} catch (Exception ex) {
    					Response.Write("Error: " + ex.Message);
    					//Note: Exception.Message returns a detailed message that describes the current exception. 
    					//For security reasons, we do not recommend that you return Exception.Message to end users in 
    					//production environments. It would be better to put a generic error message. 
    				}
    			} else {
    				Response.Write("Choose a .csv file to upload.");
    			}
    		}
    	}
    }

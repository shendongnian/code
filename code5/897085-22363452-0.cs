    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using System.Web.Configuration;
    
    namespace JamesInputProject
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            // create a helper method, just to be more readable
            private string GetReplaceText() {
                var str = WebConfigurationManager.AppSettings["REPLACE_TEXT"]; // = themessage = %1
                str = string.Format("'{0}'", str); // = 'themessage = %1'
                return str; // and use it
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
               string batchFilePath=WebConfigurationManager.AppSettings["BATCH_FILE_LOCATION"];
               string batText= File.ReadAllText(batchFilePath);
    
               // and call that method:
               string batReplacedText = batText.Replace(GetReplaceText(), txtInput.Text);
    
               //var str = WebConfigurationManager.AppSettings["REPLACE_TEXT"]; // = themessage = %1
               //str = string.Format("'{0}'", str); // = 'themessage = %1'
                //if you dont want to override existing batch file use this
                string outputFilePath = batchFilePath.Remove(batchFilePath.Length - 4) + "_" + DateTime.Now.ToString("ddMMyyyHHmm") + ".bat";
                //if you want to override existing batch file use this
                //string outputFilePath = batchFilePath;
                File.WriteAllText(outputFilePath, batReplacedText);
                lbMessage.Text = string.Format("The Batch File Input is replaced with {0} and written in the file {1}", txtInput.Text, outputFilePath);
            }
        }
    }

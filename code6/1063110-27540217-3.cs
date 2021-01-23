     private void button6_Click(object sender, EventArgs e1)
     {
       string GetHttpPost = string.Empty;
       GetHttpPost = CallHTTPPostMethod(); 
     }
     public string CallHTTPPostMethod()
     {
       try
       {
         //Your code
    
         return YourResponseXMLInStringFormat;
       }
       catch(Exception wex)
       {
         string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
         return pageContent;
       } 
      }

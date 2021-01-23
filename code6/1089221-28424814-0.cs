    using System.IO;
    using System.Web;
    using System.Net;
    WebRequest request = WebRequest.Create("http://127.0.0.1/site");
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        //Load Webpage
                    }
                }
                catch (WebException erf)
                {
                    using (WebResponse response = erf.Response)
                    {
                        var errorForm = new error();
                        errorForm.Show();
                        this.Close();
                    }
                }

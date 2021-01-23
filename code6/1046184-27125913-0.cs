        public void ProcessRequest ( HttpContext context )
        {
            string retval = string.Empty;
            string jsonString = string.Empty;
            try
            {
                    System.Diagnostics.Debug.WriteLine( "Received Post From GitLab." );
                context.Response.ContentType = "text/plain; charset=utf-8"; //"application/xml";
                HttpRequest original = context.Request;
                context.Request.InputStream.Position = 0;
                using (var inputStream = new StreamReader( context.Request.InputStream ))
                    jsonString = inputStream.ReadToEnd();
                byte[] originalstream = System.Text.Encoding.ASCII.GetBytes( jsonString );
                    System.Diagnostics.Debug.WriteLine( originalstream );
                #region respond to gitlab
                retval =
                            string.Format(
                                "JSON Received {0}",
                                DateTime.Now.ToUniversalTime() );
                context.Response.Write( retval );   //respond to gitlab, tell it received ok. (no 500)
                System.Diagnostics.Debug.WriteLine( "Responded to GitLab" ); 
                #endregion
                var jsonObject = JsonConvert.DeserializeObject<GitlabPost>( jsonString );
                    System.Diagnostics.Debug.WriteLine( "Stringified JSON" );
                //now have json object, spit it out to axosoft. 
                var hashedJSON = string.Format( "{0}{1}", jsonString, _axosoftAPIKey );
                    System.Diagnostics.Debug.WriteLine( hashedJSON );
                SHA256 hash = SHA256.Create();
                Byte[] result = hash.ComputeHash( System.Text.Encoding.ASCII.GetBytes( hashedJSON ) );
                hashedJSON = result.Aggregate( "", ( current, x ) => current + string.Format( "{0:x2}", x ) );
                    System.Diagnostics.Debug.WriteLine( "Hashed JSON from GitLab" );
                
                //now create the request to axosoft.
                HttpWebRequest newRequest = (HttpWebRequest)WebRequest.Create( new Uri( _axosoftUrl + hashedJSON ) );
                    System.Diagnostics.Debug.WriteLine( "Opened Request to Axosoft." );
                //copy over headers.
                newRequest.ContentType = original.ContentType;
                newRequest.Method = original.HttpMethod;
                newRequest.UserAgent = original.UserAgent;
                newRequest.Proxy = null;
                Stream reqStream = newRequest.GetRequestStream();
                
                reqStream.Write( originalstream, 0, originalstream.Length );
                reqStream.Close();
                    System.Diagnostics.Debug.WriteLine( "written data to stream" );
                try
                {
                    //send the post.
                    newRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.Created)
                        {
                            //post successful, carry on about your business.
                            System.Diagnostics.Debug.WriteLine( "201 Created" );
                        }
                        else if (resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            //404
                            System.Diagnostics.Debug.WriteLine( "404 Not Found" );
                        }
                        else if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            //200
                            System.Diagnostics.Debug.WriteLine( "200 OK" );
                        }
                        else
                        {
                            //unknown!
                            System.Diagnostics.Debug.WriteLine( string.Format( "Unknown Status: {0}", resp.StatusCode ) );
                        }
                    }
                    else
                    {   // dont actually throw exception in production code, that would be stupid...
                        throw new Exception("unknown exception in GetResponse(): " + ex.Message);
                    }
                }
                System.Diagnostics.Debug.WriteLine( "Sent Post Data.." );
            }
            catch (Exception error)
            {
                string err = error.Message;
                System.Diagnostics.Debug.WriteLine( "Exception: " + err );
                context.Response.ContentType = "text/plain; charset=utf-8"; //"application/xml";
                retval =
                    string.Format(
                        "JSON Post Failed at {0} because {1}",
                        DateTime.Now.ToUniversalTime(), err );
                context.Response.Write( retval );
            }
        }
    }

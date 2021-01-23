        string sLastXML;
        public string LastXML
        {
            get
            {
                return sLastXML;
            }
        }
        protected override System.Net.WebResponse GetWebResponse(System.Net.WebRequest request)
        {
            // Get the XML Returned
            System.Net.HttpWebResponse oResponse = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream oStream = oResponse.GetResponseStream();
            byte[] inStream = new byte[oResponse.ContentLength];
            int iActual = 0;
            while (iActual < oResponse.ContentLength)
            {
                iActual += oStream.Read(inStream, iActual, (int)oResponse.ContentLength - iActual);
            }
            sLastXML = System.Text.Encoding.Default.GetString(inStream);
            // Create new stream
            System.IO.MemoryStream oNewStream = new System.IO.MemoryStream();
            oNewStream.Write(inStream, 0, (int)oResponse.ContentLength);
            oNewStream.Position = 0;
            // Create new response object
            System.Net.HttpWebResponse oNewResponse = (System.Net.HttpWebResponse)System.Activator.CreateInstance(typeof(System.Net.HttpWebResponse));
            System.Reflection.PropertyInfo oInfo = oNewResponse.GetType().GetProperty("ResponseStream", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oInfo.SetValue(oNewResponse,oNewStream);
            System.Reflection.FieldInfo oFInfo = oNewResponse.GetType().GetField("m_HttpResponseHeaders", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_ContentLength", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_Verb", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_StatusCode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_StatusDescription", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_IsMutuallyAuthenticated", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_IsVersionHttp11", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_MediaType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_Uri", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oFInfo = oNewResponse.GetType().GetField("m_UsesProxySemantics", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
            oFInfo.SetValue(oNewResponse, oFInfo.GetValue(oResponse));
            oNewResponse.Cookies = oResponse.Cookies;
            return oNewResponse;
           
            
        }

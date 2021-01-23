            DateTime creationDateTime = new DateTime();
            bool creationDateTimeSpecified = false;
            string language = "NoDef";
            string transLanguage = "NoDef";
            string messageID = "NoDef";
            string maximoVersion = "NoDef";
            bool uniqueResult = false;
            string maxItems = "10000";
            string rsStart = "0";
            string rsCount = "NoDef";
            string rsTotal = "NoDef";
            MXStringType mxstringStID = new MXStringType();
            MXStringType mxstringwonum = new MXStringType();
            MXStringType mxDescription = new MXStringType();
        
            Uri serviceUri = new Uri("http://maximourl/meaweb/services/testservice");           
            BasicHttpBinding serviceBinding = new BasicHttpBinding();
            EndpointAddress EndPoint = new EndpointAddress(serviceUri);
            ChannelFactory<MXWOPortTypeChannel> channelFactory = new ChannelFactory<MXWOPortTypeChannel>(serviceBinding, EndPoint);
           
            //Create a channel 
            MXWOPortTypeChannel channel = channelFactory.CreateChannel();
            channel.Open();
            MXWOQueryType query1 = new MXWOQueryType();
            query1.WHERE = ("SITEID = 'ABC' AND STATUS='APPR'");
            QueryMXWOResponse resp1 = new QueryMXWOResponse();
            QueryMXWORequest creq = new QueryMXWORequest();
            creq.baseLanguage = language;
            //creq.creationDateTime = creationDateTime;
            creq.maximoVersion = maximoVersion;
            creq.transLanguage = transLanguage;
            creq.messageID = messageID;
            creq.rsStart = rsStart;
            creq.maxItems = maxItems;
            creq.uniqueResult = uniqueResult;
            creq.MXWOQuery = query1;
            resp1 = channel.QueryMXWO(creq);
            MXWO_WORKORDERType[] results = resp1.MXWOSet;
          
            for (int i = 0; i < results.Length; i++)
            {
                MXWO_WORKORDERType wt = results[i];
                mxstringwonum.Value = results[i].WONUM.Value;
                wt.WONUM.Value = mxstringwonum.Value;
                mxDescription.Value = results[i].DESCRIPTION.Value;
                wt.DESCRIPTION.Value = mxDescription.Value;
                mxstringStID.Value = results[i].SITEID.Value;
                wt.SITEID.Value = mxstringStID.Value;
               MessageBox.Show(mxstringStID.Value + " -- " + mxstringwonum.Value + " -- " + mxDescription.Value);
          }

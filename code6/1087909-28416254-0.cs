    byte[] data = new ASCIIEncoding().GetBytes("{ 'query' : {'__metadata': { 'type': 'SP.CamlQuery' }, 'ViewXml': '<View><Query><Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\">little test</Value></Eq></Where></Query></View>' } }");
            HttpWebRequest itemRequest =
                (HttpWebRequest)HttpWebRequest.Create(sharepointUrl.ToString() + "/_api/Web/lists/getbytitle('" + listName + "')/getitems");
            itemRequest.Method = "POST";
            itemRequest.ContentType = "application/json; odata=verbose";
            itemRequest.Accept = "application/atom+xml";
            itemRequest.Headers.Add("Authorization", "Bearer " + accessToken);
            itemRequest.ContentLength = data.Length;
            Stream myStream = itemRequest.GetRequestStream();
            myStream.Write(data, 0, data.Length);
            myStream.Close();         
            HttpWebResponse itemResponse = (HttpWebResponse)itemRequest.GetResponse();

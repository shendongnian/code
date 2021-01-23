    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Xml;
    
    namespace App
    {
        public class ListsClient : IDisposable
        {
            public ListsClient(Uri webUri, ICredentials credentials)
            {
                _client = new Lists.Lists();
                _client.Credentials = credentials;
                _client.Url = webUri + "/_vti_bin/Lists.asmx";
            }
    
            public ListsClient(Uri webUri)
            {
                _client = new Lists.Lists();
                _client.Url = webUri + "/_vti_bin/Lists.asmx";
            }
    
    
            /// <summary>
            /// Create a List Item 
            /// </summary>
            /// <param name="listName">List Name</param>
            /// <param name="propertyValues">List Item properties</param>
            /// <returns></returns>
            public XmlNode CreateListItem(string listName, Dictionary<string, string> propertyValues)
            {
                var payload = new XmlDocument();
                var updates = payload.CreateElement("Batch");
                updates.SetAttribute("OnError", "Continue");
                var method = payload.CreateElement("Method");
                method.SetAttribute("ID", "1");
                method.SetAttribute("Cmd", "New");
                foreach (var propertyValue in propertyValues)
                {
                    var field = payload.CreateElement("Field");
                    field.SetAttribute("Name", propertyValue.Key);
                    field.InnerText = propertyValue.Value;
                    method.AppendChild(field);
                }
                updates.AppendChild(method);
                return _client.UpdateListItems(listName, updates);
            }
    
            public ICredentials Credentials
            {
                get { return _client.Credentials; }
                set { _client.Credentials = value; }
            }
    
            public CookieContainer CookieContainer
            {
                get { return _client.CookieContainer; }
                set { _client.CookieContainer = value; }
            }
            
    
            public void Dispose()
            {
                _client.Dispose();
                GC.SuppressFinalize(this);
            }
    
            protected Lists.Lists _client;  //SharePoint Web Services Lists proxy
        }
    }

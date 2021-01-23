          var webHeaderCollectionFieldInfo = typeof (HttpWebResponse).GetField("m_HttpResponseHeaders",
            BindingFlags.Instance | BindingFlags.NonPublic);
    
          var webHeaderCollection = new WebHeaderCollection();
          webHeaderCollection.Set("Content-Encoding", "cheese");
          webHeaderCollectionFieldInfo.SetValue(response.Object, webHeaderCollection);

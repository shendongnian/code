    private void YourMethodWhichSavesToXml()
    {
       var serializer = new XmlSerializer(typeof(MyItem));
       using (var writer = new XmlTextWriter(@"C:\mylocation", Encoding.UTF8))
       {
          serializer.Serialize(_myItem, writer);    
       }
    }

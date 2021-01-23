     using (var client = new Service1Client("BasicHttpBinding_IService1_Longer"))
     {
         var data = client.GetData(100);
     }
     using (var client = new Service1Client("BasicHttpBinding_IService1_Shorter"))
     {
         var data = client.GetData(101);
     }

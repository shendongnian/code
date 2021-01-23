            WebClient WC = new WebClient();
            WC.Headers.Add("Content-Type", "application/json");
            WC.Encoding = Encoding.UTF8;
            MemoryStream MS = new MemoryStream();
            DataContractJsonSerializer JSrz = new 
            DataContractJsonSerializer(typeof(RequestData));
            JSrz.WriteObject(MS, order);
            string data = Encoding.UTF8.GetString(MS.ToArray(), 0, (int)MS.Length);
            
            byte[] res1 = 
            WC.UploadData("http://localhost/EMCService/Service2.svc/AddOrders", "POST",MS.ToArray());
            MS = new MemoryStream(res1);
            JSrz = new DataContractJsonSerializer(typeof(int));
            int result = (int)JSrz.ReadObject(MS);

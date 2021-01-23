            //Create your Obj Outside
            IPMAC ipObj = new IPMAC();
            foreach (Match match in matches)
            {
                Console.WriteLine("Hardware Address : {0}", match.Groups[1].Value);
                ipObj.mac = match.Groups[1].Value;
                 
            }   
            foreach (Match match in matchesIP)
            {
                Console.WriteLine("IP Address : {0}", match.Groups[1].Value);
                ipObj.ip = match.Groups[1].Value;
              
            }
            ipmac.Add(ipObj);
           private void DataGrid_Loaded(object sender, RoutedEventArgs e)
           {
            dg.ItemsSource = ipmac;
           }

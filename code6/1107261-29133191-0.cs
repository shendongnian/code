    ManagementPath path = new ManagementPath()
    {
         NamespacePath = @"root\wmi",
         Server = textBox1.Text
    };
         ManagementScope scope = new ManagementScope(path);
         SelectQuery Sq = new SelectQuery("Lenovo_BiosSetting");
         ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(scope, Sq);
         ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
         foreach (ManagementObject MO in osDetailsCollection)
         {
             if (MO["CurrentSetting"].ToString().Contains("WakeOnLAN"))
         {
             string[] arr = new string[3];
             ListViewItem itm;
             //add items to ListView
             arr[0] = "";
             arr[1] = "WakeOnLAN";
             arr[2] = MO["CurrentSetting"].ToString();
             itm = new ListViewItem(arr);
             listView200.Items.Add(itm);
        }
    }

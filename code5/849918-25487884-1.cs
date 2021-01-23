    System.Management.ObjectQuery oquery = new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");
    System.Management.ManagementObjectSearcher mosearcher = new System.Management.ManagementObjectSearcher(oquery);
    System.Management.ManagementObjectCollection moc = mosearcher.Get();
    foreach (ManagementObject mo in moc)
    {
        System.Management.PropertyDataCollection pdc = mo.Properties;
        foreach (System.Management.PropertyData pd in pdc)
        {
            if ((bool)mo["Network"])
            {
                cmbNetworkPrinters.Items.Add(mo[pd.Name].ToString());
            }
            if ((bool)mo["Local"])
            {
                cmbLocalPrinters.Items.Add(mo[pd.Name].ToString());
            }
        }
    }

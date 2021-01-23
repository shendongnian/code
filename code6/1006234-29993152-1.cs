    string uuid = string.Empty;
    ManagementClass mc = new System.Management.ManagementClass("Win32_ComputerSystemProduct");
    if (mc != null)
    {
      ManagementObjectCollection moc = mc.GetInstances();
      if (moc != null)
      {
        foreach (ManagementObject mo in moc)
        {
          PropertyData pd = mo.Properties["UUID"];
          if (pd != null)
          {
            uuid = (string)pd.Value;
            break;
          }
        }
      }
    }

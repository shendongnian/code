     System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_BIOS");
     //collection to store all management objects
     System.Management.ManagementObjectCollection moc = mc.GetInstances();
    
     if (moc.Count != 0)
     {
         foreach (System.Management.ManagementObject mo in mc.GetInstances())
         {
             // display general system information
             Console.WriteLine("\nMachine Make: [ {0} ] , Model -[  {1} ], BIOS - [ {2} ]",
                               mo["Manufacturer"].ToString(), mo["Version"].ToString(), mo["SoftwareElementID"].ToString());
         }
     }

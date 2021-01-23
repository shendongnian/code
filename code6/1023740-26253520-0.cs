    System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_ComputerSystem");
    //collection to store all management objects
    System.Management.ManagementObjectCollection moc = mc.GetInstances();
    string machinename = System.Environment.MachineName;
    if (moc.Count != 0)
    {
        foreach (System.Management.ManagementObject mo in mc.GetInstances())
        {
            // display general system information
            Console.WriteLine("\nMachine Make: {0}",
                              mo["Manufacturer"].ToString()); // contains manufacturer and model
        }
    }

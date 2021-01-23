    using System;
    using System.Diagnostics;
    using System.Management;
    class Program
    {
       static void Main(string[] args)
       {
           Double CPUtprt = 0;
           System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(@"root\WMI", "Select * From MSAcpi_ThermalZoneTemperature");
           foreach (System.Management.ManagementObject mo in mos.Get())
           {
               CPUtprt = Convert.ToDouble(Convert.ToDouble(mo.GetPropertyValue("CurrentTemperature").ToString()) - 2732) / 10;
              Console.WriteLine("CPU temp : " + CPUtprt.ToString() + " °C");
           }
       }
    }

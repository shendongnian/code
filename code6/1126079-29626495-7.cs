    private void HelperMethod()
    {
         WMIHelper help = new WMIHelper();
         foreach(ManagementObject netWorkDevice in help.GetSystemInformation())
         {
              netWorkDevice.SetPropertyValue("DNSDomainSuffixSearchOrder", new object[] {"domain.x"});
              //or
              netWorkDevice.SetPropertyValue("DNSDomainSuffixSearchOrder", "domain.x");
              //or
              netWorkDevice["DNSDomainSuffixSearchOrder"] = "suffix.com";
              //or
              netWorkDevice["DNSDomainSuffixSearchOrder"] = new object[]{"suffix.com"};
              printer.Put(); //Save
              Console.WriteLine();
              Console.WriteLine();
              Console.WriteLine("Next Device");
              Console.WriteLine();
              foreach(var prop in help.GetPropertiesOfManagmentObj(netWorkDevice))
              {
                   if (prop.Name != "DNSDomainSuffixSearchOrder") { continue; }
                   if (prop.Value == null) { continue; }
                   foreach(var value in (string[])prop.Value)
                   {
                        Console.WriteLine(prop.Name + "         " + value);
                   }
              }
         }
    }

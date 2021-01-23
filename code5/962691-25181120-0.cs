    private void getOSActivation()
    {
       try
       {
         ManagementObjectSearcher LicenseSearcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT LicenseStatus,Description FROM SoftwareLicensingProduct");
         foreach (ManagementObject LSObj in LicenseSearcher.Get())
         {
           OStestString = LSObj["Description"].ToString().ToLower();
           if (
               OStestString.Contains("operating") 
               &&
               // next line is new
               (OStestString.Contains("slp") || OStestString.Contains("dm"))
              )
              {
                foreach (var item in LSObj.Properties)
                {
                  OSresults.Add(LSObj["LicenseStatus"].ToString());
                }
              }
            }
          }
        catch (Exception LSOexception)
        {
          Console.WriteLine(LSOexception.Message);
        }
      }

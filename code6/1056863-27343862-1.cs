      public const string CProgIdOutlook = "Outlook.Application";
      /// <summary>
      /// Method to get the Outlook version number, which will presumably be 11 (2003), 12 (2007), 
      /// 14 (2010) or 15 (2013). (I wonder what happened to version 13?) An exception is thrown if 
      /// this method is unable to provide an answer.
      /// 
      /// The technique used to get the version number of the "current" installed version of Outlook 
      /// is one of many possible methods that are described in various Internet sources, and is 
      /// hopefully the most likely to provide the correct answer with the least side-effects. 
      /// Problems with some of the alternative registry-based methods typically show up when 
      /// multiple versions of Outlook are installed or have been installed. The registry values can 
      /// also depend on x86 vs. x64 systems and whether Outlook was installed for one user or for 
      /// all users. Techniques involving querying the Outlook automation object have the 
      /// disadvantage of an instance of the Outlook program getting created - this can be seen in 
      /// Task Manager.
      /// 
      /// The idea for this code came from here: http://support.microsoft.com/kb/240794
      /// </summary>
      /// <returns>11 (2003), 12 (2007), 14 (2010) or 15 (2013)</returns>
      private static int GetOutlookVersion()
      {
         const string CRegistryKey = @"SOFTWARE\Classes\" + GroupwareProgIds.CProgIdOutlook;
         int outlookVersion;
         using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(CRegistryKey))
         {
            outlookVersion = GetOutlookVersion(registryKey);
            if (outlookVersion != -1)
               return outlookVersion;
         }
         using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(CRegistryKey))
         {
            outlookVersion = GetOutlookVersion(registryKey);
            if (outlookVersion != -1)
               return outlookVersion;
         }
         throw new MerliniaException(0x2d4a67fu, "No registry entry for " + CRegistryKey);
      }
      /// <summary>
      /// Sub-method of above method to do the work for either HKLM or HKCU.
      /// </summary>
      /// <returns>11 (2003), 12 (2007), 14 (2010) or 15 (2013), or -1 for error</returns>
      private static int GetOutlookVersion(RegistryKey registryKey1)
      {
         const string CCurVer = "CurVer";
         if (registryKey1 == null)
            return -1;
         using (RegistryKey registryKey2 = registryKey1.OpenSubKey(CCurVer))
         {
            if (registryKey2 == null)
               throw new MerliniaException(0x2d43e5au, 
                                          "No registry entry for " + registryKey1 + "\\" + CCurVer);
            string currentOutlookAppName = registryKey2.GetValue(null) as string;
            if (currentOutlookAppName != null)
            {
               string[] sa = currentOutlookAppName.Split('.');
               if (sa.Length == 3)
               {
                  int outlookVersion;
                  if (int.TryParse(sa[2], NumberStyles.Integer, 
                                   CultureInfo.InvariantCulture, out outlookVersion))
                     return outlookVersion;
               }
            }
            throw new MerliniaException(0x2d4b29du, 
                                   "Invalid registry content for " + registryKey1 + "\\" + CCurVer);
         }
      }

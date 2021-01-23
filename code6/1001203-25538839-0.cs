      // Mutex object used to determine if there are multiple instances of this program running. 
      //  Note that this is a reference to a .Net Mutex object, not the Windows mutex itself.
      private static Mutex _onlyOneInstanceMutex;
      /// <summary>
      /// Method to test that there is not another instance of the program already running on this 
      /// machine, or at least in this Terminal Services session or Windows Vista / Windows 7 
      /// concurrent sessions session. If there is, a message box-style localized error message is 
      /// displayed and the value false is returned. This implies that this method should not be 
      /// used in programs that are run as a Windows service.
      /// 
      /// This implementation uses a .Net Mutex object in public storage to prevent it from being 
      /// garbage-collected. The name of the associated Windows mutex is simply the program name as 
      /// provided by the caller. Neither the .Net Mutex object nor the Windows mutex are ever 
      /// explicitly released; they remain in existence, perhaps in an "abandoned" state, until the 
      /// process that created them terminates.
      /// </summary>
      /// <returns>false if another instance running, otherwise true</returns>
      [SuppressMessage("Microsoft.Reliability", "CA2004:RemoveCallsToGCKeepAlive",
                       Justification = "Not sure if this is correct or not.")]
      public static bool TestOnlyOneInstance(string programName)
      {
         // Funny construct to prevent the Mutex from being garbage collected
         GC.KeepAlive(_onlyOneInstanceMutex);
         // Test if we are the first instance, and if so create the Windows mutex, making it 
         //  impossible for subsequent instances to successfully create their mutex
         bool firstInstance;
         _onlyOneInstanceMutex = new Mutex(false, programName, out firstInstance);
         if (firstInstance)
            return true;
         // Display a (possibly localized) error message, then return
         string errorMessage = MLocalizer.GetString("Error1", 
               "Another instance of this program is already running on this machine.") +
             "\n" + MLocalizer.GetString("Error2",
                                         "You cannot run two instances at the same time.") +
             "\n" + MLocalizer.GetString("Error3", "Please use the other instance.");
         MessageBox.Show(errorMessage, programName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         return false;
      }

     <!-- language: c# -->
        
        // No double buffering for remote, only local
        public bool OptimizeOfLocalFormsOnly(System.Windows.Forms.Control chartControlForm)
        {
         if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
         {
                  SetUpDoubleBuffer(chartControlForm);
                  return true;
         }
         return false;
        
        }
        
        public static void SetUpDoubleBuffer(System.Windows.Forms.Control chartControlForm)
        {
                  
           System.Reflection.PropertyInfo formProp = 
           typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",         System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);    
           formProp.SetValue(chartControlForm, true, null); 
        }

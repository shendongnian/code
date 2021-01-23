        static void Test()
        {
            if (!HasAdministratorRights())
            {
                // throw error to notfying that the app need admin rights
            }
            // Get files for 
        }
        private static bool HasAdministratorRights()
        {
            var currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity == null)
                return false;
            return new WindowsPrincipal(currentIdentity)
                .IsInRole(WindowsBuiltInRole.Administrator);
        }

    internal static class RegistryHelper
    {
        ////////////////////////////////////////////////
        #region Statics
        /// <summary>
        /// A dictionary of registry roots and their subkeys to handle.
        /// </summary>
        private static readonly Dictionary<RegistryHive, string[]> RegistryKeys = new Dictionary<RegistryHive, string[]>
        {
            {
                RegistryHive.ClassesRoot,
                new []
                {
                    @"*\shell\QuickHash",
                    @"*\shell\QuickHash\command",
                    @"Directory\shell\QuickHash",
                    @"Directory\shell\QuickHash\command"
                }
            }
        };
        /// <summary>
        /// The registry default value for the command keys.
        /// </summary>
        private static readonly string RegistryCommandValue;
        #endregion
        ////////////////////////////////////////////////
        #region Constructors
        static RegistryHelper()
        {
            RegistryCommandValue = String.Format("\"{0}\" /file \"%1\"", Assembly.GetExecutingAssembly().Location);
        }
        #endregion
        ////////////////////////////////////////////////
        #region Public Methods
        /// <summary>
        /// Ensures that all required registry keys exist and adjusts their values if required.
        /// </summary>
        public static void EnsureRegistryKeyIntegrity()
        {
            foreach (var registryRoot in RegistryKeys.Keys)
            {
                foreach (var registryKeyName in RegistryKeys[registryRoot])
                {
                    if (((App)Application.Current).Config.EnableExplorerContextMenu)
                    {
                        var regKey = GetOrAddKey(registryRoot, registryKeyName);
                        AdjustKey(regKey);
                        regKey.Close();
                    }
                    else
                    {
                        DeleteKey(registryRoot, registryKeyName);
                    }
                }
            }
        }
        #endregion
        ////////////////////////////////////////////////
        #region Private Methods
        /// <summary>
        /// Gets or adds a specific key for a specific registry root.
        /// </summary>
        /// <param name="registryRoot">The registry root.</param>
        /// <param name="registryKeyName">The registry key.</param>
        /// <returns>Returns the gotten or added registry key.</returns>
        private static RegistryKey GetOrAddKey(RegistryHive registryRoot, string registryKeyName)
        {
            switch (registryRoot)
            {
                case RegistryHive.ClassesRoot:
                    return Registry.ClassesRoot.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.ClassesRoot.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.CurrentUser:
                    return Registry.CurrentUser.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.CurrentUser.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.LocalMachine:
                    return Registry.LocalMachine.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.LocalMachine.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.Users:
                    return Registry.Users.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.Users.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.PerformanceData:
                    return Registry.PerformanceData.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.PerformanceData.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.CurrentConfig:
                    return Registry.CurrentConfig.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.CurrentConfig.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                case RegistryHive.DynData:
                    // DynData is obsolete
                    return Registry.PerformanceData.OpenSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue) ??
                           Registry.PerformanceData.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                default:
                    throw new ArgumentOutOfRangeException("registryRoot");
            }
        }
        /// <summary>
        /// Deletes an unused registry key.
        /// </summary>
        /// <param name="registryRoot">The registry root.</param>
        /// <param name="registryKeyName">The registry key.</param>
        private static void DeleteKey(RegistryHive registryRoot, string registryKeyName)
        {
            const string missingRightsText = "You don't have the permissions to perform this action.";
            const string missingRightsCaption = "Error";
            try
            {
                switch (registryRoot)
                {
                    case RegistryHive.ClassesRoot:
                        Registry.ClassesRoot.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.CurrentUser:
                        Registry.CurrentUser.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.LocalMachine:
                        Registry.LocalMachine.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.Users:
                        Registry.Users.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.PerformanceData:
                        Registry.PerformanceData.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.CurrentConfig:
                        Registry.CurrentConfig.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    case RegistryHive.DynData:
                        // DynData is obsolete
                        Registry.PerformanceData.DeleteSubKeyTree(registryKeyName, false);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("registryRoot");
                }
            }
            catch (SecurityException)
            {
                MessageBox.Show(missingRightsText, missingRightsCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(missingRightsText, missingRightsCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Adjusts the registry keys value.
        /// </summary>
        /// <param name="regKey">The registry key to adjust.</param>
        private static void AdjustKey(RegistryKey regKey)
        {
            if (regKey.Name.EndsWith("QuickHash"))
            {
                SetExplorerShellName(regKey);
                SetExplorerShellIcon(regKey);
                return;
            }
            if (regKey.Name.EndsWith("command"))
            {
                var keyDefaultValue = regKey.GetValue("") as String;
                if (String.IsNullOrEmpty(keyDefaultValue)
                 || keyDefaultValue != RegistryCommandValue)
                {
                    regKey.SetValue(null, RegistryCommandValue, RegistryValueKind.String);
                }
                return;
            }
            
            throw new NotSupportedException("Given registry key is not supported.");
        }
        private static void SetExplorerShellName(RegistryKey regKey)
        {
            const string quickHashDisplayName = "Quick Hash";
            var keyDefaultValue = regKey.GetValue("") as String;
            if (String.IsNullOrEmpty(keyDefaultValue)
                || keyDefaultValue != quickHashDisplayName)
            {
                regKey.SetValue(null, quickHashDisplayName, RegistryValueKind.String);
            }
        }
        private static void SetExplorerShellIcon(RegistryKey regKey)
        {
            var executingAssembly = (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            regKey.SetValue("Icon", String.Format("{0},0", executingAssembly));
        }
        #endregion
    }

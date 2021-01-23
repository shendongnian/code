     public class Configuration
        {
            private const DayOfWeek FailsafeDefaultDayOfWeek = DayOfWeek.Saturday;
    
            /// <summary>
            /// A default for the day of week
            /// </summary>
            public static DayOfWeek DefaultDayOfWeek
            {
                get
                {
                    string dayOfWeekString = GetSettingValue("DefaultDayOfWeek");
    
                    try
                    {
                        return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeekString);
                    }
                    catch (Exception)
                    {
                        // If someone screws up and forgets to include a value, or the value cannot be cast:
                        return FailsafeDefaultDayOfWeek;
                    }
                }
            }
    
            /// <summary>
            /// Helper method to easily pull a value from a configuration store.
            /// </summary>
            /// <param name="settingName"></param>
            /// <returns></returns>
            private static string GetSettingValue(string settingName)
            {
                try
                {
                    return System.Configuration.ConfigurationManager.AppSettings[settingName];
                }
                catch (Exception)
                {
                    throw new MissingConfigurationValueException(settingName);
                }
            }
        }

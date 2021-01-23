    private static int compareVersionNumbers(string installedVersion, string requiredVersion)
        {
            if (installedVersion.Equals(requiredVersion))
            {
                Console.WriteLine("Versions are identical.");
                return 0;
            }
            else if (installedVersion != (requiredVersion))
            {
                // Split version strings into arrays.
                List<string> versionArray = installedVersion.Split('.').ToList<string>();
                List<string> otherVersionArray = requiredVersion.Split('.').ToList<string>();
                int count = 0;
                while ((count < versionArray.Count()) && (count < otherVersionArray.Count()))
                {
                    // Fetch current version component
                    int currentPart = Convert.ToInt32(versionArray.ElementAt(count));
                    int otherPart = Convert.ToInt32(otherVersionArray.ElementAt(count));
                    if (currentPart > otherPart)
                    {
                        Console.WriteLine(installedVersion + " is greater than " + requiredVersion);
                        return 1;
                        break;
                    }
                    else if (currentPart < otherPart)
                    {
                        Console.WriteLine(installedVersion + " is less than " + requiredVersion);
                        return -1;
                        break;
                    }
                    count++;
                }
               
            }
            return 0;
        }

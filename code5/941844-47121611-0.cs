            var assembly = typeof(App).GetTypeInfo().Assembly;
            var AssemblyName = assembly.GetName().Name;
            var generatedFilename = AssemblyName+".Images.flags.flag_" + item.CountryCode?.ToLower() + @".png";
                bool found = false;
                foreach (var res in assembly.GetManifestResourceNames())
                {
                    if (res == generatedFilename)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) UseGeneratedFilename();
                else UseSomeOtherPlaceholderImage;
            

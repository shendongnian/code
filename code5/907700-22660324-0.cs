    private async void LaunchPDF(string name)
            {
                string file = @"Data\PDF\"+name+".pdf";
    
                // Get the image file from the package's image directory
                var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
                if (file != null)
                {
                    bool success = await Windows.System.Launcher.LaunchFileAsync(file);
                    if (success)
                    {
                        // File launched
                        Debug.WriteLine("File Launched");
                    }
                    else
                    {
                        // File launch failed
                        Debug.WriteLine("File Launched Failed");
                    }
                }
                else
                {
                    // Could not find file
                    Debug.WriteLine("Could not find the file");
                }
            }

         private async void privacyPolicy_Click(object sender, EventArgs e)
              {
            var installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var assets = await installedLocation.GetFolderAsync("Assets");
            var pdf = await assets.GetFileAsync("PrivacyPolicy.pdf");
            await Windows.System.Launcher.LaunchFileAsync(pdf);
        }

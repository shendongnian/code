	internal class CodeConnectUpdater
	{
		IVsExtensionManager _extensionManager;
		IVsExtensionRepository _extensionRepository;
		//We need only supply the download URL.
		//This can be retrieved from the "Download" button on your extension's page.
		private class CodeConnectRepositoryEntry : IRepositoryEntry
		{
			public string DownloadUpdateUrl
			{
				get; set;
			}
			public string DownloadUrl
			{
				get
				{
                    //NOTE: YOU MUST TRIM THE DOWNLOAD URL
                    //TO NOT CONTAIN A VERSION. THIS FORCES 
                    //THE GALLERY TO DOWNLOAD THE LATEST VERSION
					return "http://visualstudiogallery.msdn.microsoft.com/c0c2ad47-957c-4e07-89fc-20996595b6dd/file/140793/";
				}
				set
				{
					throw new NotImplementedException("Don't overwrite this.");
				}
			}
			public string VsixReferences
			{
				get; set;
			}
		}
		//I have been calling this from the VSPackage's Initilize, passing in the component model
		public bool CheckForUpdates(IComponentModel componentModel)
		{
			_extensionRepository = (IVsExtensionRepository)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SVsExtensionRepository));
			_extensionManager = (IVsExtensionManager)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SVsExtensionManager));
			//Find the extension you're after.
			var extension = _extensionManager.GetInstalledExtensions().Where(n => n.Header.Name == "Code Connect Alpha").SingleOrDefault();
			return CheckAndInstallNewVersion(extension);
		}
		private bool CheckAndInstallNewVersion(IInstalledExtension myExtension)
		{
			var needsRestart = false;
			var entry = new CodeConnectRepositoryEntry();
			var newVersion = FetchIfUpdated(myExtension, entry);
			if (newVersion != null)
			{
				Install(myExtension, newVersion);
				needsRestart = true;
			}
			return needsRestart;
		}
		//Checks the version of the extension on the VS Gallery and downloads it if necessary.
		private IInstallableExtension FetchIfUpdated(IInstalledExtension extension, CodeConnectRepositoryEntry entry)
		{
			var version = extension.Header.Version;
			var strNewVersion = _extensionRepository.GetCurrentExtensionVersions("ExtensionManagerQuery", new List<string>() { "6767f237-b6e4-4d95-9982-c9e898f72502" }, 1033).Single();
			var newVersion = Version.Parse(strNewVersion);
			if (newVersion > version)
			{
				var newestVersion = _extensionRepository.Download(entry);
				return newestVersion;
			}
			return null;
		}
		
		private RestartReason Install(IInstalledExtension currentExtension, IInstallableExtension updatedExtension)
		{
			//Uninstall old extension
			_extensionManager.Disable(currentExtension);
			_extensionManager.Uninstall(currentExtension);
			//Install new version
			var restartReason = _extensionManager.Install(updatedExtension, false);
			//Enable the newly installed version of the extension
			var newlyInstalledVersion = _extensionManager.GetInstalledExtension(updatedExtension.Header.Identifier);
			if (newlyInstalledVersion != null)
			{
				_extensionManager.Enable(newlyInstalledVersion);
			}
			return restartReason;
		}
	}

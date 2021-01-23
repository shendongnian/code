    private void ZipTheFolder() {
    	try {
    		if (File.Exists(ZipPath)) {
    			File.Delete(ZipPath);
    		}
    		ZipFile.CreateFromDirectory(FolderFromZipLocation, ZipPath);
    	}
    	catch(Exception ex) {
    		throw new CustomConfigurationException($ "Error when zip: {ex.Message}");
    	}
    }

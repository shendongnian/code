        /// <summary>
        /// Copies all the files from the Resource Manifest to the relevant folders. 
        /// </summary>
        internal void CopyAllFiles()
        {
            var resourceFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var item in resourceFiles)
            {
                string basePath = Resources.ResourceManager.BaseName.Replace("Properties.", "");
                if (!item.Contains(basePath))
                    continue;
                var destination = this._rootFolder + "\\" + this._javaScriptFolder + "\\" + item.Replace(basePath + ".", "");
                using (Stream resouceFile = Assembly.GetExecutingAssembly().GetManifestResourceStream(item))
                using (Stream output = File.Create(destination))
                {
                    resouceFile.CopyTo(output);
                }
            }
        }

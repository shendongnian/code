    public class FileExtensionMap {
        private Dictionary<string, IViewer> maps;
        public IViewer this[string key] {
            get {
                if (!this.maps.ContainsKey(key)) {
                    throw new KeyNotFoundException();
                }
    
                return this.maps[key];
            }
        }
    
        public FileExtensionMap() {
            this.maps = new Dictionary<string, IViewer>();
        }
    
        public void AddMapping(string fileExt, IViewer viewer) {
            if (!this.maps.ContainsKey(fileExt)) {
                this.maps.Add(fileExt, viewer);
            }
        }
    }

    public class Example {
        FileExtensionMap map;
    
        public Example(FileExtensionMap map) {
            this.map = map;
        }
    
        public void View(FileInfo file) {
            map[file.Extension].LaunchViewer(file.Name);
        }
    }

    public class MyStorageFile {
        StorageFile File { get; set; }
        String MyProperty { get; set; }
    }
    public class MyStorageFolder : StorageFolder {
        public async Task<MyStorageFile> CreateFileAsync(string x)
        {             
    		MyStorageFile file = new MyStorageFile();         
    		file.File =  (MyStorageFile) await ApplicationData.Current.LocalFolder.CreateFileAsync(x.Replace('/', '_'));
            	return file;
        }
    
    }

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private const string FilePath = "{0}.txt";
        private readonly List<ItemView> items = new List<ItemView>(); 
        private void WriteFile(object sender, RoutedEventArgs e)
        {
            var fileName = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            // Convert text to bytes.
            byte[] data = Encoding.UTF8.GetBytes(fileName);
            // Encrypt byutes.
            byte[] protectedBytes = ProtectedData.Protect(data, null);
            // Store the encrypted bytes in iso storage.
            this.WriteToFile(protectedBytes, fileName);
        }
        private void ReadFiles(object sender, RoutedEventArgs e)
        {
            items.Clear();
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var files = isoStore.GetFileNames("*.txt");
                foreach (var file in files)
                {
                    // Retrieve the protected bytes from isolated storage.
                    byte[] protectedBytes = this.ReadBytesFromFile(file);
                    // Decrypt the protected bytes by using the Unprotect method.
                    byte[] bytes = ProtectedData.Unprotect(protectedBytes, null);
                    // Convert the data from byte to string and display it in the text box.
                    items.Add(new ItemView { LineOne = file, LineTwo = Encoding.UTF8.GetString(bytes, 0, bytes.Length) });
                }
            }
            //Show all the data...
            MessageBox.Show(string.Join(",", items.Select(i => i.LineTwo)));
        }
        private void WriteToFile(byte[] bytes, string fileName)
        {
            // Create a file in the application's isolated storage.
            using (var file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var writestream = new IsolatedStorageFileStream(string.Format(FilePath, fileName), System.IO.FileMode.Create, System.IO.FileAccess.Write, file))
                {
                    // Write data to the file.
                    using (var writer = new StreamWriter(writestream).BaseStream)
                    {
                        writer.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        private byte[] ReadBytesFromFile(string filePath)
        {
            // Access the file in the application's isolated storage.
            using (var file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var readstream = new IsolatedStorageFileStream(filePath, System.IO.FileMode.Open, FileAccess.Read, file))
                {
                    // Read the data in the file.
                    using (var reader = new StreamReader(readstream).BaseStream)
                    {
                        var ProtectedPinByte = new byte[reader.Length];
                        reader.Read(ProtectedPinByte, 0, ProtectedPinByte.Length);
                        return ProtectedPinByte;
                    }
                }
            }
        }
    }
    public class ItemView
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
    }

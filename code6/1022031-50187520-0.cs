MainWindow.xaml
    <StackPanel>
        <Button
            Margin="50"
            Height="50"
            Content="BEGIN UPLOAD"
            Click="OnButtonClick" />
        <ContentControl
            Content="{Binding Path=ProgressBar}" />
    </StackPanel>
MainWindow.xaml.cs
    public partial class MainWindow
    {
        readonly ViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new ViewModel(Dispatcher);
            DataContext = _viewModel;
            InitializeComponent();
        }
        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            _viewModel.UploadAsync().ConfigureAwait(false);
        }
    }
ViewModel.cs
    public class ViewModel
    {
        readonly Dispatcher _dispatcher;
        
        public ViewModel(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            ProgressBar = new ProgressBar {Height=30};
        }
    
        public async Task UploadAsync()
        {
            // Google Cloud Platform project ID.
            const string projectId = "project-id-goes-here";
            // The name for the new bucket.
            const string bucketName = projectId + "-test-bucket";
            // Path to the file to upload
            const string filePath = @"C:\path\to\image.jpg";
            var newObject = new Google.Apis.Storage.v1.Data.Object
            {
                Bucket = bucketName,
                Name = System.IO.Path.GetFileNameWithoutExtension(filePath),
                ContentType = "image/jpeg"
            };
            // read the JSON credential file saved when you created the service account
            var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromJson(System.IO.File.ReadAllText(
                @"c:\path\to\service-account-credentials.json"));
            // Instantiates a client.
            using (var storageClient = Google.Cloud.Storage.V1.StorageClient.Create(credential))
            {
                try
                {
                    // Creates the new bucket. Only required the first time.
                    // You can also create buckets through the GCP cloud console web interface
                    storageClient.CreateBucket(projectId, bucketName);
                    System.Windows.MessageBox.Show($"Bucket {bucketName} created.");
                    // Open the image file filestream
                    using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
                    {
                        ProgressBar.Maximum = fileStream.Length;
                        // set minimum chunksize just to see progress updating
                        var uploadObjectOptions = new Google.Cloud.Storage.V1.UploadObjectOptions
                        {
                            ChunkSize = Google.Cloud.Storage.V1.UploadObjectOptions.MinimumChunkSize
                        };
                        // Hook up the progress callback
                        var progressReporter = new Progress<Google.Apis.Upload.IUploadProgress>(OnUploadProgress);
                        await storageClient.UploadObjectAsync(
                                newObject, 
                                fileStream,
                                uploadObjectOptions,
                                progress: progressReporter)
                            .ConfigureAwait(false);
                    }
                }
                catch (Google.GoogleApiException e)
                    when (e.Error.Code == 409)
                {
                    // When creating the bucket - The bucket already exists.  That's fine.
                    System.Windows.MessageBox.Show(e.Error.Message);
                }
                catch (Exception e)
                {
                    // other exception
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
        }
        // Called when progress updates
        void OnUploadProgress(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case Google.Apis.Upload.UploadStatus.Starting:
                    ProgressBar.Minimum = 0;
                    ProgressBar.Value = 0;
                    break;
                case Google.Apis.Upload.UploadStatus.Completed:
                    ProgressBar.Value = ProgressBar.Maximum;
                    System.Windows.MessageBox.Show("Upload completed");
                    break;
                case Google.Apis.Upload.UploadStatus.Uploading:
                    UpdateProgressBar(progress.BytesSent);
                    break;
                case Google.Apis.Upload.UploadStatus.Failed:
                    System.Windows.MessageBox.Show("Upload failed"
                                                   + Environment.NewLine
                                                   + progress.Exception);
                    break;
            }
        }
        void UpdateProgressBar(long value)
        {
            _dispatcher.Invoke(() => { ProgressBar.Value = value; });
        }
        // probably better to expose progress value directly and bind to 
        // a ProgressBar in the XAML
        public ProgressBar ProgressBar { get; }
    }

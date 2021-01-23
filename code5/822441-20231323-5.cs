    public class ImagesModel : ObservableObject
	{
		private ObservableCollection<string> _HardDrives;
		public ObservableCollection<string> HardDrives
		{
			get
			{
				return this._HardDrives;
			}
			set
			{
				if (this._HardDrives != value)
				{
					this._HardDrives = value;
					OnPropertyChanged(() => this.HardDrives);
				}
			}
		}
		private string _CurrentDrive;
		public string CurrentDrive
		{
			get
			{
				return this._CurrentDrive;
			}
			set
			{
				if (this._CurrentDrive != value)
				{
					this._CurrentDrive = value;
					OnPropertyChanged(() => this.CurrentDrive);
					// enumerate files in this drives
					string[] supportedExtensions = new[] { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
					this.Images = new ObservableCollection<PhotoModel>(
						System.IO.Directory.EnumerateFiles(value, "*.*")
						.Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower()))
						.Select(filename => new PhotoModel(filename)));
				}
			}
		}
		private ObservableCollection<PhotoModel> _Images;
		public ObservableCollection<PhotoModel> Images
		{
			get
			{
				return this._Images;
			}
			set
			{
				if (this._Images != value)
				{
					this._Images = value;
					OnPropertyChanged(() => this.Images);
				}
			}
		}
		private PhotoModel _CurrentImage;
		public PhotoModel CurrentImage
		{
			get
			{
				return this._CurrentImage;
			}
			set
			{
				if (this._CurrentImage != value)
				{
					this._CurrentImage = value;
					OnPropertyChanged(() => this.CurrentImage);
				}
			}
		}
		public ImagesModel()
		{
			this.HardDrives = new ObservableCollection<string>(Environment.GetLogicalDrives());
		}
	}
	public class PhotoModel : ObservableObject
	{
		private string _FileName;
		public string FileName
		{
			get
			{
				return this._FileName;
			}
			private set
			{
				if (this._FileName != value)
				{
					this._FileName = value;
					OnPropertyChanged(() => this.FileName);
				}
			}
		}
		private ImageSource _Image;
		public ImageSource Image {
			get
			{
				return this._Image;
			}
			private set
			{
				if (this._Image != value)
				{
					this._Image = value;
					OnPropertyChanged(() => this.Image);
				}
			}
		}
		public PhotoModel(string filename)
		{
			BitmapImage img = new BitmapImage();
			img.BeginInit();
			img.CacheOption = BitmapCacheOption.OnLoad;
			img.UriSource = new Uri(filename, UriKind.Absolute);
			img.DecodePixelWidth = 64;	// or whatever
			img.EndInit();
			this.Image = img;
		}
	}

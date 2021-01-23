  		public class Serializer
	{
		public static Stream Serialize<T>(T t)
		{
			var memoryStream = new MemoryStream();
			var serializer = new BinaryFormatter();
			serializer.Serialize(memoryStream, t);
			return memoryStream;
		}
		public static T Deserialize<T>(Stream stream)
		{
			var formatter = new BinaryFormatter();
			stream.Seek(0, SeekOrigin.Begin);
			return (T)formatter.Deserialize(stream);
		}
	}
	public Task<BitmapImage> ApplyImageEffect(ImageSource imageSource, Effect effect, Size size)
	{
		var imgSourceSerialized = Serializer.Serialize(imageSource);
		var effectSerialized = Serializer.Serialize(effect);
		return Task.Factory.StartNew(() =>
		{
			var imgSourceDeserialized = Serializer.Deserialize<ImageSource>(imgSourceSerialized);
			var effectDeserialized = Serializer.Deserialize<Effect>(effectSerialized);
			var drawingVisual = new DrawingVisual();
			var drawingContext = drawingVisual.RenderOpen();
			drawingContext.DrawImage(imgSourceDeserialized, new Rect(new Point(0, 0), size));
			drawingVisual.Effect = effectDeserialized;
			drawingContext.Close();
			var frameRenderTargetBitmap2 = new RenderTargetBitmap((int)size.Width,
																				 (int)size.Height,
																				  1 / 96,
																				  1 / 96,
																				  PixelFormats.Default);
			frameRenderTargetBitmap2.Render(drawingVisual);
			var frameBitmapFrame2 = BitmapFrame.Create(frameRenderTargetBitmap2);
			var memoryStream = new MemoryStream();
			var encoder = new PngBitmapEncoder();
			encoder.Frames.Add(frameBitmapFrame2);
			encoder.Save(memoryStream);
			var bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = memoryStream;
			bitmapImage.EndInit();
			// important!
			bitmapImage.Freeze();
			return bitmapImage;
		});
	}
	public MainWindow()
	{
		InitializeComponent();
		Task<BitmapImage> [] tasks = new[]
		{
			ApplyImageEffect(new BitmapImage(), new BlurEffect(), new Size(20, 20)),
			ApplyImageEffect(new BitmapImage(), new BlurEffect(), new Size(20, 20))
		};
		Task.WaitAll(tasks);
	}

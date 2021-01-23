	public class ApplicationStorageHelper
	{
		private static readonly JsonSerializer jsonSerializer = JsonSerializer.Create();
		public static async Task<bool> SaveData<T>(T data)
		{
			var file =
				await ApplicationData.Current.RoamingFolder.CreateFileAsync("settings.dat", CreationCollisionOption.ReplaceExisting);
			using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (var outputStream = stream.GetOutputStreamAt(0))
				{
					using (var writer = new StreamWriter(outputStream.AsStreamForWrite()))
					{
						var jsonWriter = new JsonTextWriter(writer);
						jsonSerializer.Serialize(jsonWriter, data);
						return true;
					}
				}
			}
		}
		public static async Task<T> LoadData<T>()
		{
			try
			{
				var file =
					await ApplicationData.Current.RoamingFolder.GetFileAsync("settings.dat");
				using (var inputStream = await file.OpenSequentialReadAsync())
				{
					using (var reader = new StreamReader(inputStream.AsStreamForRead()))
					{
						var jsonReader = new JsonTextReader(reader);
						return jsonSerializer.Deserialize<T>(jsonReader);
					}
				}
			}
			catch (FileNotFoundException)
			{
				return default(T);
			}
		}
	}

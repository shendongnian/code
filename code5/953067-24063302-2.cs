	public class Program
	{
		public static void Main(string[] args)
		{
			System.Drawing.Bitmap image;
			var originalFile = @"C:\Users\Public\Pictures\Sample Pictures\test.jpg";
			var newFile = @"C:\Users\Public\Pictures\Sample Pictures\test2.jpg";
			using (var fileLoadImage = System.Drawing.Bitmap.FromFile(originalFile))
			{
				image = new System.Drawing.Bitmap(fileLoadImage);
			}
			image.Save(newFile);
			System.IO.File.Delete(originalFile);
			image.Dispose();
			System.IO.File.Delete(newFile);
		}
	}

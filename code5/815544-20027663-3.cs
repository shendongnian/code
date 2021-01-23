    Imports System
    Imports System.Drawing
    Imports System.IO
    Imports System.Windows
    Imports System.Windows.Interop
    Imports System.Windows.Media.Imaging
    Namespace StackConsoleTesting
	Class Program
		Private Function BitmapImage2Bitmap(bitmapImage As BitmapImage) As Bitmap
			BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));
			Using outStream = New MemoryStream()
				Dim enc As BitmapEncoder = New BmpBitmapEncoder()
				enc.Frames.Add(BitmapFrame.Create(bitmapImage))
				enc.Save(outStream)
				Dim bitmap As New System.Drawing.Bitmap(outStream)
				Return New Bitmap(bitmap)
			End Using
		End Function
		<System.Runtime.InteropServices.DllImport("gdi32.dll")> _
		Public Shared Function DeleteObject(hObject As IntPtr) As Boolean
		End Function
		Private Function Bitmap2BitmapImage(bitmap As Bitmap) As BitmapImage
			Dim hBitmap As IntPtr = bitmap.GetHbitmap()
			Dim retval As BitmapImage

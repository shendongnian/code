		/// <summary>Returns a string resource from a DLL.</summary>
		/// <param name="DLLHandle">The handle of the DLL (from LoadLibrary()).</param>
		/// <param name="ResID">The resource ID.</param>
		/// <returns>The name from the DLL.</returns>
		static string GetStringResource(IntPtr handle, uint resourceId) {
			StringBuilder buffer = new StringBuilder(8192);		//Buffer for output from LoadString()
			int length = NativeMethods.LoadString(handle, resourceId, buffer, buffer.Capacity);
			return buffer.ToString(0, length);		//Return the part of the buffer that was used.
		}
		static class NativeMethods {
			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
			internal static extern IntPtr LoadLibrary(string lpLibFileName);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
			internal static extern int LoadString(IntPtr hInstance, uint wID, StringBuilder lpBuffer, int nBufferMax);
			[DllImport("kernel32.dll")]
			public static extern int FreeLibrary(IntPtr hLibModule);
		}

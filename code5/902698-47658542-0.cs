    public static class PowerPointInterOp
	{
		static PowerPoint.Application powerPointApp = null;
		static Object oMissing = System.Reflection.Missing.Value;
		static Object oTrue = true;
		static Object oFalse = false;
		static Object oCopies = 1;
		
		public static void InitializeInstance()
		{
			if (powerPointApp == null)
			{
				powerPointApp = new PowerPoint.ApplicationClass();
			}			
		}
		
		public static void KillInstances()
		{
			try
			{
				Process[] processes = Process.GetProcessesByName("POWERPNT");
				foreach(Process process in processes)
				{
					process.Kill();
				}
			}
			catch(Exception)
			{
				
			}
		}
		
		public static void CloseInstance()
		{
			if (powerPointApp != null)
			{
				powerPointApp.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(powerPointApp);
				powerPointApp = null;
			}
		}
		
		public static PowerPoint.Presentation OpenDocument(string documentPath)
		{
			InitializeInstance();
			
			PowerPoint.Presentation powerPointDoc = powerPointApp.Presentations.Open(documentPath, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
				
			return powerPointDoc;
		}
		
		public static void CloseDocument(PowerPoint.Presentation powerPointDoc)
		{
			if (powerPointDoc != null)
			{
				powerPointDoc.Close();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(powerPointDoc);
				powerPointDoc = null;
			}			
		}
		
		
	}

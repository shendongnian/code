		private bool IsWordFileOpened()
		{
		   bool isExist = false;
		   System.Diagnostics.Process[] prs = System.Diagnostics.Process.GetProcesses();        
		   foreach (Process pr in prs)
		   {
			  if (pr.ProcessName == "WINWORD")
			  {
				isExist = true;
				break;
			  }
		   }
		   return isExist;
		}

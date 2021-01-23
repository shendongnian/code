    class Program
    {
    	public static void Main(string[] args)
    	{
    		AcadApplication acAppComObj = null;
    		
    		//Query your Regedit Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Autodesk\AutoCAD to get the correctly suffix that specifies the version
    		const string strProgId = "AutoCAD.Application.20";
    		
    		// Get a running instance of AutoCAD
    		try
    		{
    			acAppComObj = (AcadApplication)Marshal.GetActiveObject(strProgId);
    		}
    		catch // An error occurs if no instance is running
    		{
    			try
    			{
    				// Create a new instance of AutoCAD
    				acAppComObj = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(strProgId), true);
    			}
    			catch
    			{
    				// If an instance of AutoCAD is not created then message and exit
    				System.Windows.Forms.MessageBox.Show("Instance of 'AutoCAD.Application'" +
    													 " could not be created.");
    		
    				return;
    			}
    		}
    		
    		// Display the application
    		if (null != acAppComObj)
            {
                try
                {
                    int i = 0;
                    AcadState appState = app.GetAcadState();
                    while (!appState.IsQuiescent)
                    {
                        if (i == 120)
                        {
                            Environment.Exit(-1);
                        }
                        // Wait .25s
                        Thread.Sleep(250);
                        i++;
                    }
                    app.Visible = true;
                    var docs = app.Documents;
                    docs.Add("acadiso.dwt");
                }
                catch (COMException err)
                {
                    if (err.ErrorCode.ToString() == "-2147417846")
                    {
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Falha durante a obtenção do documento ativo.", ex);
                }
            }
            else
            {
                throw new Exception("Erro to open first document.");
            }
    		
    											 
    		// Open AutoCAD project file, use this code if all DWGs is associated with a AutoCAD Project with Server Database
    		#region ' Open Project '
    		acDocComObj.SendCommand("FILEDIA","0");
    		acDocComObj.SendCommand("-OPENPROJECT", "C:\\\\Users\\<username>\\Documents\\ProjectFolder\\Project.xml");
    		acDocComObj.SendCommand("FILEDIA","1");
    		#endregion
    											 
    		string[] dwgFiles = //To do: add here the rule that list all full path DWG files
    		AcadDocuments docs = app.Documents;
    		foreach(string dwgPath in dwgFiles)
    		{
    			docs.Open(dwgPath, true);
    			Thread.Sleep(3000);
    			AcadDocument acadDoc = acAppComObj.ActiveDocument;
    			
    			acDocComObj.SendCommand("FILEDIA","0");
    			acadDoc.SendCommand("JPGOUT ", "C:\\\\Users\\<username>\\Images\\" + Path.GetFileName(dwgPath) + ".jpg");
    			acDocComObj.SendCommand("FILEDIA","1");
    		}
    	}
    }

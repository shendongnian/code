    static void Main(string[] args)
    {
    	var fileName = string.Empty;
    	var filePath = @"C:\Users\myfolder\Documents\RGReports\"; //for testing purposes only 
    	List<string> listNames = new List<string>();
    	string[] filePaths = Directory.GetFiles(@filePath);
    	foreach (string file in filePaths)
    	{
    		if (file.Contains(".txt"))
    		{
    			fileName = file;
    			using (StreamReader sr = File.OpenText(fileName))
    			{
    				//string s = String.Empty;
    				var tempFile = sr.ReadToEnd();
    				var splitFile = tempFile.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
    				foreach (string str in splitFile)
    				{
    					if (str.Length == 12)
    					{
    						listNames.Add(str.Substring(0, str.Length).Replace("0", "").Replace("1", "").Replace("2A",""));
    					}
    					Console.WriteLine(str);
    				}
    			}
    		}
    	}
    }

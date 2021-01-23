    Dictionary<String, String> caseOptions = new Dictionary<String, String>();
    Dictionary<String, Byte[]> PDF = new Dictionary<String,Byte[]>();
    Dictionary<String, Byte[]>[] files = new Dictionary<String, Byte[]>[1];
    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    // below will log into our FogBugz URL to use the FBApi
    FogBugz.Init();
    string fileName = @"C:\path\to\test.pdf";
    // setup any necessary values
    caseOptions.Add("sEvent", "Attaching PDF file");
    caseOptions.Add("ixBug", "9999");
    // setup required keys
    PDF.Add("name", encoding.GetBytes("File1"));
    PDF.Add("filename", encoding.GetBytes(fileName));
    PDF.Add("contenttype", encoding.GetBytes("multipart/form-data"));
    PDF.Add("data", File.ReadAllBytes(fileName));
    files[0] = PDF;
                    
    FogBugz.fb.XCmd("edit", caseOptions, files);

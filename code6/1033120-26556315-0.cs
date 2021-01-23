    GetFileList myList = new GetFileList(@"c:\temp");
    public static void GetFiles(GetFileList listOfFiles)
    {
        //Gets files and lists last access time
        for (int i = 0; i < listOfFiles.fileList.Length; i++) //using param
        {
            Console.WriteLine(listOfFiles.fileList[i]); //using param
        }
    }
    GetFiles(myList);
     

    foreach (object item in listBox1.Items)
    {
    	foreach (string file in pdf_specFiles)
    	{
            var fileName = pdf_specFiles.FirstOrDefault(f => f.Equals(item.ToString()));
    		if (fileName!=null)
    		{
    			printList.Add(Path.GetFullPath(file));
    		}
    	}
    }
    if(!printList.Any())
            throw new FileNotFoundException();
    foreach (string file in printList)
    {
    	PrintDocument(file);
    	System.Threading.Thread.Sleep(10000); // wait 10 second say
    	Application.DoEvents(); // keep UI responsive if Windows Forms app
    }

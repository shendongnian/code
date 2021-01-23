	int lineNum = 1;
	
	foreach (string line in System.IO.File.ReadAllLines(myFilePath))
	{
	    if (lineNum < 100)
	    {
	        listBox1.Items.Add(line);
	    }
	    else
	    {
	        listBox2.Items.Add(line);
	    }
	    
	    lineNum++;
	}

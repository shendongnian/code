    	var filePath = "Your csv file path here including name";
    	var newFilePath = filePath + ".tmp";
    
    	using (StreamReader vReader = new StreamReader(filePath))
    	{
    		using (StreamWriter vWriter = new StreamWriter(newFilePath, false, Encoding.ASCII))
    		{
    			int vLineNumber = 0;
    			while (!vReader.EndOfStream)
    			{
    				string vLine = vReader.ReadLine();
    				vWriter.WriteLine(ReplaceLine(vLine, vLineNumber++));
    			}
    		}
    	}
    
    	File.Delete(filePath);
    	File.Move(newFilePath, filePath);
    
    	Dts.TaskResult = (int)ScriptResults.Success;
    }
    
    protected string ReplaceLine(string Line, int LineNumber)
    {
    	var newLine = Line.Replace("\",\"", "|");
    	newLine = newLine.Replace(",\"", "|");
    	newLine = newLine.Replace("\",", "|");
    	return newLine;
    }

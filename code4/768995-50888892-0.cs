    void Main()
    {
    	using (System.IO.StreamWriter sw = System.IO.File.AppendText("file.txt"))
    	{          
    		string first = reader[0].ToString();
    		string second=image.ToString();
    		string csv = string.Format("{0},{1}\n", first, second);
    		sw.WriteLine(csv);
    	}
    } 

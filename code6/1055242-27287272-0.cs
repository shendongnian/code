    private void RunFileOperation(string inputFile, string search)
    {
    	Timer t = new Timer();
    	int progress = 0;
    	StringBuilder sb = new StringBuilder();
    
    	// Filesize serves as max value to check progress
    	progressBar1.Maximum = (int)(new FileInfo(inputFile).Length);
    	t.Tick += (s, e) =>
    		{
    			rtbLog.Text = sb.ToString();
    			progressBar1.Value = progress;
    			if (progress == progressBar1.Maximum)
    			{
    				t.Enabled = false;
    				tssLbl.Text = "done";
    			}
    		};
    	//update every 0.5 second		
    	t.Interval = 500;
    	t.Enabled = true;
        // Start async file read operation
    	System.Threading.Tasks.Task.Factory.StartNew(() => delete_Lines(inputFile, search, ref progress, ref sb));		
    }
    
    private void delete_Lines(string fileName, string searchString, ref int progress, ref StringBuilder sb)
    {
    	using (var file = File.OpenText(fileName))
    	{
    		int i = 0;
    		while (!file.EndOfStream)
    		{
    			var line = file.ReadLine();
    			progress = (int)file.BaseStream.Position;
    			if (line.Contains(searchString))
    			{
    				sb.AppendFormat("Deleting(row {0}):\n{1}", (i + 1), line);
    				// Change this algorithm for nextline check
    				// Do this when it is next line, i.e. in this line.
    				// "If" check above can check if (line.startswith(" "))...
    				// instead of having to do it nextline next here.
    				/*if (cbDB == true)
    				{
    					while (is_next_line_block(lines, i) == true)
    					{
    						i++;
    						rtbLog.Text += lines[i] + "\n";
    						progressBar1.Value += 1;
    					}
    				}*/
    			}
    		}
    	}			
    	sb.AppendLine("...Deleting finished\n");
    }
 

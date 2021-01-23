    private void SaveItems()
    {
    	using(StreamWriter sw = new StreamWriter("file.txt"))
    	{
    		for (int i = 0; i < listBox1.Items.Count; i++)
    		{
    			sw.WriteLine(listBox1.Items[i]);
    		}
    	}
    }

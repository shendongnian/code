		var s =  "1110011011010000";
		var window = 8;
		System.Text.StringBuilder sb = new System.Text.StringBuilder(s);
		for(int i=0; i <= s.Length-window; i=i+window)
		{
			char c =sb[i+window-1];			
			sb.Remove(i+window-1,1);
			sb.Insert(i,c);			
		}
		string result = sb.ToString();

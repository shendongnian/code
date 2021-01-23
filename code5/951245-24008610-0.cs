		public string SearchText()
        {
          
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
    
            foreach (string line in lines)
            {
				var l= line.Split.(',');
                if(l[0].Contain("326785")){
				return l[1];
				}
            }
        }

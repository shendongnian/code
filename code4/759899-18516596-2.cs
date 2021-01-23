    	protected void search_Click(object sender, EventArgs e)
	{
		StreamReader sr = new StreamReader("colorCode.txt");
		string line = null;
		
		char []colorSeparator =  { ':' } ;
		string []colors ;
		
		char []colorCodeSeparator =  { '#' } ;
		string []codeAndColor ;
		
		bool found ;
		string colorToSearch ;
		string colorCode ;
		colorToSearch  = "White" ;
		found = false ;
		while(!found && (line =sr.ReadLine()) !=null)
		{
			//separate the content of the file "#FFFFFF"#White: "#FF0000"#Red: using ":" as separator
			colors = line.Split(colorSeparator) ;
			foreach(string color in colors)
			{
				codeAndColor = colors.Split(colorCodeSeparator) ;
				//codeAndColor[0] now contains the colorCode "#FFFFFF"
				//codeAndColor[1] contains the name of the color "White"
				
				//check if the name of the color in the file contains the colorToSearch allowing for case insensitive
				if(codeAndColor[1].ToUpper().Contains(colorToSearch.ToUpper()))
				{
					colorCode = codeAndColor[0].Substring(1,7) ; //the 1 is to skip the initial double quote, 7 is the number of caracter to take
					found = true ;
					//stop the foreach loop
					break ;
				}
			}
		}
	}

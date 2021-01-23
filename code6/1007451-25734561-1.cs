	private void textBox11_TextChanged(object sender, EventArgs e)
    {
        string originalText = "N14 G73 X315.2 Y83.7 I40.0 J6.4 A0.0 H3 K75 T11 F5 M0 C0.0";
        string[] splitString = originalText.Split(new Char[] { ' ' });
		
		foreach(String str in splitString)
		{
			switch(str[0])
			{
				case 'N':
					Console.WriteLine("1: " + str.Substring(1));
					break;
				case 'G':
					Console.WriteLine("2: " + str.Substring(1));
					break;
				case 'X':
					Console.WriteLine("3: " + str.Substring(1));
					break;
				case 'Y':
					Console.WriteLine("4: " + str.Substring(1));
					break;
				case 'I':
					Console.WriteLine("5: " + str.Substring(1));
					break;
				case 'J':
					Console.WriteLine("6: " + str.Substring(1));
					break;
				case 'H':
					Console.WriteLine("7: " + str.Substring(1));
					break;
				case 'K':
					Console.WriteLine("8: " + str.Substring(1));
					break;
				case 'F':
					Console.WriteLine("9: " + str.Substring(1));
					break;
				case 'T':
					Console.WriteLine("10: " + str.Substring(1));
					break;				
			}
		}       
    }

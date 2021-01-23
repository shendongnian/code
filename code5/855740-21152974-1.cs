			var strMyString = @"start
			asdf
			end";
			byte[] ASCIIValues = System.Text.Encoding.ASCII.GetBytes(strMyString);
			string strENL = "";
			foreach (byte b in ASCIIValues)
			{
				strENL += b + " ";
			}
			Console.WriteLine("strMyString is as ascii: " + strENL);
			/////////
			Console.WriteLine("\n\n");
			var str2 = strMyString.Replace("\r","");
			Console.WriteLine("string 2 matches == " + (strMyString == str2).ToString());
			
			var str3 = strMyString.Replace("\n", "");
			Console.WriteLine("string 3 matches == " + (strMyString == str3).ToString());
			var str4 = strMyString.Replace(Environment.NewLine,"\n");
			Console.WriteLine("string 4 matches == " + (strMyString == str4).ToString());
			var str5 = strMyString.Replace(Environment.NewLine, "\r");
			Console.WriteLine("string 4 matches == " + (strMyString == str5).ToString());
			/////////
			Console.WriteLine("\n\n");
			strENL = "";
			ASCIIValues = System.Text.Encoding.ASCII.GetBytes(Environment.NewLine);
			
			foreach (byte b in ASCIIValues)
			{
				strENL += b;
			}
			Console.WriteLine("Environment.NewLine is as ascii: " + strENL);
			/////////
			
			Console.WriteLine("\n\n");
			Console.WriteLine((Environment.NewLine == "\n").ToString());
			Console.WriteLine((Environment.NewLine == "\r").ToString());
			Console.WriteLine((Environment.NewLine == "\r\n").ToString());		

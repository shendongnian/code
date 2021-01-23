        static int PrintBlock(int offset, int y, int maxLineLength, string text)
		{ 
			//get the words
			var parts = text.Split(new char[] { ' ' });
			int i=0;
			var sb = new StringBuilder();
			for (; i < parts.Length; i++)
			{
				if (sb.Length + parts[i].Length < maxLineLength)
				{
					sb.Append(parts[i]);
					sb.Append(" ");
				}
				else
				{
					//this is a line
					Console.SetCursorPosition(offset, y);
					Console.Write(sb.ToString().Trim());
					sb.Clear();
					i--;
					y++;
				}
			}
			//print the last line
			Console.SetCursorPosition(offset, y);
			Console.Write(sb.ToString().Trim());
            y++;
            return y;
		}

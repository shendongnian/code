    	public static string HideCharacter()
		{
			ConsoleKeyInfo key;
			string code = "";
			do
			{
				key = Console.ReadKey(true);
				if (Char.IsNumber(key.KeyChar))
				{
					
						Console.Write("*");
				}
					code += key.KeyChar;
				}
			} while (key.Key != ConsoleKey.Enter);
			return code;
		}
password = HideCharacter();

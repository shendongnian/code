    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class ButtonEntry
    {
    	public int Number { get; set; } 
    	public string Text { get; set; }
    	public string Program { get; set; }
    	public string BackgroundColor { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		// Load data...
    		var data = new List<string>
    		{
    			"buttons=2",
    			";",
    			"button_text_01=a",
    			"button_text_02=b",
    			"button_program_02=p",
    			"button_bckcolor_02=c",
    		};
    
    		// Find number of buttons.
    		string buttonString = ReadData(data, "buttons");
    		int buttonCount = int.Parse(buttonString);
    
    		var buttons = new List<ButtonEntry>();
    
    		// Fill each button.
    		for (int b = 1; b <= buttonCount; b++)
    		{
    			var button = new ButtonEntry
    			{
    				Number = b
    			};
    			
    			string needle = "button_text_" + b.ToString("D2");	
    			button.Text = ReadData(data, needle);
    			needle = "button_program_" + b.ToString("D2");	
    			button.Program = ReadData(data, needle);
    			needle = "button_bckcolor_" + b.ToString("D2");	
    			button.BackgroundColor = ReadData(data, needle);
    			
    			buttons.Add(button);
    		}
    		
    		foreach (var button in buttons)
    		{
    			Console.WriteLine("Button {0}: {1}, {2}, {3}", button.Number, button.Text, button.Program, button.BackgroundColor);
    		}
    	}
    	
    	/// <summary>
    	/// Finds the line in <paramref name="data" /> that starts with
    	/// <paramref name="needle" /> followed by "=", returning the 
    	/// value after "=" or null when not found.
    	/// </summary>
    	public static string ReadData(List<string> data, string needle)
    	{
    		var line = data.FirstOrDefault(s => s.StartsWith(needle));
    		if (line == null)
    		{
    			return null;
    		}
    		
    		return line.Substring(line.IndexOf("=") + 1);
    	}
    }

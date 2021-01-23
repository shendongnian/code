    using System;
	using System.Text;
	using System.Collections.Generic;
	using System.Linq;
	using System.Diagnostics;
	 
	public class Test
	{
		public static void Main()
		{
			string all = Convert.ToString("In every case it will be last name — some text here OR last name — some-sort of text OR last-name — more text, here OR last name — more-text here").Replace(",", " ");
			int hyph1 = all.IndexOf('—');
			int hyph2 = hyph1 + all.Substring(++hyph1).IndexOf('—');
			string partial = all.Substring(0, ++hyph2).Replace("—", " ");
			string res = String.Concat(partial, "—", all.Substring(++hyph2).Replace("—", " ").Replace("-", ","));
			Console.Write(res.ToString());
		}
	}

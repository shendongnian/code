		static void Main(string[] args)
		{
				var tal1=1; var tal2=2;
				MsgBox("Hello!\nResult:{0}\n", (tal1 + tal2));
				MsgBox("Calculation: {0} + {1} = {2}", tal1, tal2, (tal1+tal2));
		}
		public static MsgBoxResult MsgBox(string msg, params object[] p)
		{
			var fmt=string.Format(msg, p);
			var msgStyle= Microsoft.VisualBasic.MsgBoxStyle.OkOnly;
			return Interaction.MsgBox(fmt, msgStyle, "Information");
		}

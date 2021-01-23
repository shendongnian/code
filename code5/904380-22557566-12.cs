		public Microsoft.VisualBasic.MsgBoxResult MsgBox(string msg, params object[] p)
		{
			var fmt = string.Format(msg, p);
			var msgStyle = Microsoft.VisualBasic.MsgBoxStyle.OkOnly;
			return Interaction.MsgBox(fmt, msgStyle, "Information");
		}

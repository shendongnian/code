		public void MsgBox(string msg, params object[] p)
		{
			var fmt=string.Format(msg, p);
			Interaction.MsgBox(fmt);
		}

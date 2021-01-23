		void PassMessage(Message m)
		{
			if (Engine != null)
				Engine.ProcessWindowMessage(m.Msg, m.WParam, m.LParam);
		}
		
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (!designMode)
				PassMessage(m);
		}

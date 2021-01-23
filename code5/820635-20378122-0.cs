    public class CustomActions
	{
		[CustomAction]
		public static ActionResult CopyToClipboard(Session session)
		{
			ActionResult ar=ActionResult.Success;
			session.Log("Begin CopyToClipboard");
			//MessageBox.Show("Begin Copy");
			string str="abcde";
			MessageBox.Show(" "+str);
			try
			{
				Thread th=new Thread(new ParameterizedThreadStart(ClipboardThread));
				th.SetApartmentState(ApartmentState.STA);
				th.Start(str);
				th.Join();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message+" \n"+ex.StackTrace);
				ar=ActionResult.Failure;
			}
			//MessageBox.Show("End Copy");
			return ar;
		}
		static void ClipboardThread(object s)
		{
			try
			{
				Clipboard.SetText(s.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message+" \n"+ex.StackTrace);
			}
		}

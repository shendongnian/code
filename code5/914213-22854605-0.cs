    public partial class Form1 : Form
	{
		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (var val in Enum.GetNames(typeof(COMMS_MESSAGE_ID_t)))
			{
				cbCANcmd.Items.Add(new CommsMessage(val));
			}
		}
	}
	public class CommsMessage
	{
		public string Name { get; set; }
		public COMMS_MESSAGE_ID_t Message { get; set; }
		public CommsMessage(string msgName)
		{
			Name = msgName;
			Message = (COMMS_MESSAGE_ID_t)Enum.Parse(typeof (COMMS_MESSAGE_ID_t), msgName);
		}
		public override string ToString()
		{
			return string.Format("{0:x} - {1}", Message, Name);
		}
	}

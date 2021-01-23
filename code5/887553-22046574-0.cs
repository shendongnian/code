    public class myClass{
    ...
	private ICommandInfo commandInfo= new CommandInfo();
	private void GetInfo(Channel channel, string message)
	{
		Match match = Regex.Match(message, "@info (.+)");
		if (match.Success)
		{
			string search = match.Groups[1].Value;
			//Get stored data on the word or sentence, and send the result to chat.
			commandInfo.Execute(search);  //<-------------------- no object creation.
			return;
		}
		Chat.SendAdminMessage("Message not found.");
	}
    ...
    }

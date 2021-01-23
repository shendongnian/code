    public static class MessageSenderManagerFactory
    {
      public static MessageSenderManager Create(IRecipient recipient)
      {
        return new MessageSenderManager { Recipient = recipient };
      }
    }
    public class MessageSenderManager
    {
      public IRecipient Recipient { get; set; }
      public bool SendMessage(string message)
      {
        // Use this.Recipient.GetRecipient() somewhere here
        // If you need to differentiate between EmailRecipient and NameRecipient
        // you can use:
        //   if (Recipient is EmailRecipient) ...
        //   else if (Recipient is NameRecipient) ...
      }
    }
    public interface IRecipient
    {
      public string GetRecipient();
    }
    public class EMailRecipient : IRecipient
    {
      protected string Email;
      public EMailRecipient(string data)
      {
        Email = data;
      }
      public string GetRecipient() { return Email }
    }
    public class NameRecipient : IRecipient
    {
      protected string Name;
      public EMailRecipient(string data)
      {
        Name = data;
      }
      public string GetRecipient() { return Name }
    }

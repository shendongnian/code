    public static class MessageSenderManagerFactory
    {
      public static IMessageSenderManager Create(IRecipient recipient)
      {
        return new MessageSenderManager { Recipient = recipient };
      }
    }
    public interface IMessageSenderManager
    {
      public IRecipient Recipient { get; set; }
      bool SendMessage(string message);
    }
    public class MessageSenderManager : IMessageSenderManager
    {
      public IRecipient Recipient { get; set; }
      public bool SendMessage(string message)
      {
        // At this point you construct the actual message and sending mechanism.
        // You'll have all the information you need in the TheUser property of Recipient.
        // The following is an example how this can be implemented but since you have not
        // provided what information you need to send or HOW you send the message I can't
        // be more specific.
        var messageToSend = new Message(message);
        messageToSend.Address = Recipient.GetRecipientAddress();
        messageToSend.Send();
      }
    }
    public interface IRecipient
    {
      public string GetRecipientAddress();
    }
    public abstract class RecipientBase
    {
      public User TheUser { get; set; }
      private RecipientBase() { }
      protected RecipientBase(string userId) { TheUser = FindUserById(userId); }
    }
    public class MailRecipient : RecipientBase, IRecipient
    {
      public MailRecipient(string userId) : base(userId) { }
      public string GetRecipientAddress() { return TheUser.Mail; }
    }
    public class UserNameRecipient : RecipientBase, IRecipient
    {
      public UserNameRecipient(string userId) : base(userId) { }
      public string GetRecipientAddress() { return TheUser.UserName; }
    }

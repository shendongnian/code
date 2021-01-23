    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;
    class App
    {
      static void Main()
      {
         var mail = new MailMessage("aaa@bbb.ccc", "ddd@eee.fff", "Test Subj", "Test Body");
         var client1 = new SmtpClient("localhost");
         var client2 = new SmtpClient("localhost");
         var task1 = client1.SendMailAsync(mail);
         var task2 = client2.SendMailAsync(mail);
         Task.WhenAll(task1, task2).Wait();
      }
    }

        using System;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using Microsoft.Azure.ServiceBus;
        using Microsoft.Azure.ServiceBus.Core;
        using System.Text;
        using System.Collections.Generic;
        using System.Threading.Tasks;
    
        namespace ClearDeadLetterQ
    
    {
        [TestClass]
        public class UnitTest1
        {
    
            const string ServiceBusConnectionString = "Endpoint=sb://my-domain.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yoursharedaccesskeyhereyoursharedaccesskeyhere";
    
    
            [TestMethod]
            public async Task TestMethod1()
            {
                await this.ClearDeadLetters("my.topic.name", "mysubscriptionname/$DeadLetterQueue");
            }
    
            public async Task ClearDeadLetters(string topicName, string subscriptionName)
            {
                var messageReceiver = new MessageReceiver(ServiceBusConnectionString, EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName), ReceiveMode.PeekLock);
                var message = await messageReceiver.ReceiveAsync();
                while ((message = await messageReceiver.ReceiveAsync()) != null)
                {
                    await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
                }
                await messageReceiver.CloseAsync();
            }
        }
    }

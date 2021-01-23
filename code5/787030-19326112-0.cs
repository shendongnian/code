    public class OrderQueueProcessingService : OrderQueueProcessingServiceBase, IDisposable
    {
        #region Constructors
        public OrderQueueProcessingService()
        {
            Initialize(ConfigurationManager.AppSettings["OrderQueueProcessingQueueName"]);
        }
        public OrderQueueProcessingService(List<EventRecord> existingList) : base(existingList) {}
        #endregion
        #region Properties
        private MessageQueue Queue { get; set; }
        #endregion
        #region IDisposable Members
        public new void Dispose()
        {
            if (Queue == null) return;
            //unsubscribe and dispose
            Queue.PeekCompleted -= QueueOnPeekCompleted;
            Queue.Dispose();
        }
        #endregion
        private void Initialize(string queueName)
        {
            Queue = new MessageQueue(queueName, false, true, QueueAccessMode.Receive)
                        {
                                Formatter = new XmlMessageFormatter(new[] {typeof (OrderQueueDataContract)})
                        };
            //setup events and start.
            Queue.PeekCompleted += QueueOnPeekCompleted;
            Queue.BeginPeek();
        }
        private static void MoveMessageToDeadLetter(IDisposable message)
        {
            var q = new MessageQueue(ConfigurationManager.AppSettings["OrderProcessingDLQ"], QueueAccessMode.Send)
                        {
                                Formatter = new XmlMessageFormatter(new[] {typeof (OrderQueueDataContract)})
                        };
            q.Send(message, MessageQueueTransactionType.Single);
            q.Dispose();
        }
        /// <summary>
        ///     Processes the specified Order message
        /// </summary>
        /// <param name="orderMessage"></param>
        public override void ProcessOrderQueue(OrderQueueDataContract orderMessage)
        {
            using (var unitOfWork = new MyDataContext())
            {
                switch (orderMessage.M.ToLower())
                {
                    case "create":
                        DataAccessLayer.CreateOrder(unitOfWork, orderMessage.O.TranslateToBe());
                        break;
                    default:
                        break;
                }
            }
        }
        private void QueueOnPeekCompleted(object sender, PeekCompletedEventArgs peekCompletedEventArgs)
        {
            var asyncQueue = (MessageQueue) sender;
            using (var transaction = new MessageQueueTransaction())
            {
                transaction.Begin();
                try
                {
                    using (var message = asyncQueue.ReceiveById(peekCompletedEventArgs.Message.Id, TimeSpan.FromSeconds(30), transaction))
                    {
                        if (message != null) ProcessOrderQueue((OrderQueueDataContract) message.Body);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    transaction.Abort();
                }
                catch (Exception ex)
                {
                    transaction.Abort();
                }
                if (transaction.Status != MessageQueueTransactionStatus.Aborted) transaction.Commit();
                else
                {
                    using (var message = asyncQueue.ReceiveById(peekCompletedEventArgs.Message.Id, TimeSpan.FromSeconds(30), transaction))
                    {
                        if (message != null)
                        {
                            MoveMessageToDeadLetter(message);
                            message.Dispose();
                        }
                    }
                    EventLog.WriteEntry("OrderQueueProcessingService", "Could not process message: " + peekCompletedEventArgs.Message.Id);
                }
                transaction.Dispose();
            }
            asyncQueue.EndPeek(peekCompletedEventArgs.AsyncResult);
            asyncQueue.BeginPeek();
        }
    }

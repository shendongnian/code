    public class Telegram<T>
    {
        public int Sender { get; private set; }
        public int Receiver { get; private set; }
        //Message of an enumerated messageToSend in Messages
        public Message MessageToSend { get; private set; }
        //for delayed messages
        public double DispatchTime { get; set; }
        //for any additional info
        public T ExtraInfo { get; private set; }
        public Telegram(double time, int otherSender, int otherReceiver,
                    Message otherMessage, T info = default(T))
        {
            DispatchTime = time;
            Sender = otherSender;
            Receiver = otherReceiver;
            MessageToSend = otherMessage;
            ExtraInfo = info;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /*Telegrams are stored in a priority queue. Therefore the < and ==
        operators are overloaded so the PQ can sort the telegrams
        by time priority. Times must be smaller than 
        SmallestDelay before two Telegrams are considered unique.*/
        public const double SmallestDelay = 0.25;
        public static bool operator ==(Telegram<T> t1, Telegram<T> t2)
        {
            return (Math.Abs(t1.DispatchTime - t2.DispatchTime) < SmallestDelay) &&
             (t1.Sender == t2.Sender) &&
             (t1.Receiver == t2.Receiver) &&
             (t1.MessageToSend == t2.MessageToSend);
        }
        public static bool operator !=(Telegram<T> t1, Telegram<T> t2)
        {
            return (Math.Abs(t1.DispatchTime - t2.DispatchTime) > SmallestDelay) &&
             (t1.Sender != t2.Sender) &&
             (t1.Receiver != t2.Receiver) &&
             (t1.MessageToSend != t2.MessageToSend);
        }
        public static bool operator <(Telegram<T> t1, Telegram<T> t2)
        {
            if (t1 == t2)
                return false;
            else
                return (t1.DispatchTime < t2.DispatchTime);
        }
        public static bool operator >(Telegram<T> t1, Telegram<T> t2)
        {
            if (t1 == t2)
                return false;
            else
                return (t1.DispatchTime > t2.DispatchTime);
        }
    }
    public sealed class MessageDispatcher
    {
        public const double sendMessageImmediately = 0.0;
        public const int noAdditionalInfo = 0;
        public const int senderIdIrrelevant = -1;
        //a set is used as the container for the delayed messages
        //because of the benefit of automatic sorting and avoidance
        //of duplicates. Messages are sorted by their dispatch time.
        private static SortedSet<Telegram<object>> priorityQueue = new SortedSet<Telegram<object>>();
        /// <summary>
        /// this method is utilized by DispatchMessage or DispatchDelayedMessages.
        /// This method calls the messageToSend handling member function of the receiving
        /// entity, receiver, with the newly created telegram
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="messageToSend"></param>
        private static void Discharge<T>(BaseEntityInfo receiver, Telegram<T> message)
        {
            if (!receiver.HandleMessage(message))
            {
                //telegram could not be handled
            }
        }
        private MessageDispatcher() { }
        public static readonly MessageDispatcher instance = new MessageDispatcher();
        /// <summary>
        /// given a messageToSend, a receiver, a sender and any time delay, this function
        /// routes the messageToSend to the correct entity (if no delay) or stores it
        /// in the messageToSend queue to be dispatched at the correct time. Entities referenced 
        /// by iD.
        /// </summary>
        public static void DispatchMessage<T>(double delay, int sender,
                                int otherReceiver, Message message,
                                T additionalInfo = default(T))
        {
            //get the reciever
            BaseEntityInfo receiver = EntityMgr.entityManager.GetEntityFromID(otherReceiver);
            //make sure the Receiver is valid
            if (receiver == null)
                return;
            //create the telegram
            var telegram = new Telegram<object>(0, sender, otherReceiver, message, additionalInfo);
            //if there is no delay, route telegram immediately                       
            if (delay <= 0.0)
                //send the telegram to the recipient
                Discharge(receiver, telegram);
            //else calculate the time when the telegram should be dispatched
            else
            {
                double CurrentTime = Clock.Current();
                telegram.DispatchTime = CurrentTime + delay;
                //and put it in the queue
                priorityQueue.Add(telegram);
            }
        }
        /// <summary>
        /// This function dispatches any telegrams with a timestamp that has
        /// expired. Any dispatched telegrams are removed from the queue as it
        /// sends out any delayed messages. This method is called each time through   
        /// the main game loop.
        /// </summary>
        public static void DispatchDelayedMessages()
        {
            double CurrentTime = Clock.Current();
            //now peek at the queue to see if any telegrams need dispatching.
            //remove all telegrams from the front of the queue that have gone
            //past their sell by date
            while (!(priorityQueue.Count == 0) &&
                    (priorityQueue.ElementAt(0).DispatchTime < CurrentTime) &&
                    (priorityQueue.ElementAt(0).DispatchTime > 0))
            {
                //read the telegram from the front of the queue
                var telegram = priorityQueue.ElementAt(0);
                //find the recipient
                BaseEntityInfo receiver = EntityMgr.entityManager.GetEntityFromID(telegram.Receiver);
                //send the telegram to the recipient
                Discharge(receiver, telegram);
                //remove it from the queue
                priorityQueue.Remove(priorityQueue.ElementAt(0));
            }
        }
    }

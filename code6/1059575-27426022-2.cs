    using System;
    using System.Threading;
    
    namespace StackOverflowPlayground
    {
            public class AirportSim
            {
                public Flight flight = new Flight("1","","",1);
    
                public AirportSim()
                {
                    InitializeEvents();
                }
    
                private void InitializeEvents()
                {
                    
                    flight.LogMessage += OnLogReceived;
                }
    
                public void OnLogReceived(object sender, System.EventArgs e)
                {
                    string msgcontent = ((Flight.MessageEventArgs)e).msgContent;
                    Console.WriteLine(msgcontent);
                }
            }
        public class Flight
        {
            public class MessageEventArgs : EventArgs
            {
                public string msgContent;
            }
    
            public event EventHandler LogMessage;
    
            public Flight(string flightNumber, string departure, string destination, int totalLoadCapacity)
            {
                FlightNumber = flightNumber;
                Departure = departure;
                Destination = destination;
                TotalLoadCapacity = totalLoadCapacity;
                //LogMessage += (s, o) => { };
            }
    
            public string Destination { get; set; }
    
            public int TotalLoadCapacity { get; set; }
    
            public string Departure { get; set; }
    
            public string FlightNumber { get; set; }
    
            public void StartFlight()
            {
                string tmpDeparture = this.Departure;
                string tmpDestination = this.Destination;
                OnLogUpdate("Taking off from " + tmpDeparture + " now.");
                Destination = tmpDeparture;
                Thread.Sleep(1000);
                OnLogUpdate("Arriving in " + tmpDestination + " now.");
                Departure = tmpDestination;
            }
    
            protected void OnLogUpdate(string logMessage)
            {
                if (logMessage == "")
                    return;
    
                var e = new MessageEventArgs();
                var handler = LogMessage;
    
                if (handler != null)
                {
                    e.msgContent = logMessage;
                    handler(this, e);
                }
            }
        }
    
    }

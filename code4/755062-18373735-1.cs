    public class Route {
        public int Number { get; private set; }
        
        public string Port { get; private set; }
        
        public string Destination { get; private set; }
        
        public Route(int number, string port, string destination) {
            Number = number;
            Port = port;
            Destination = destination;
        }
    }
    
    public class Flight {
        public DateTime DepartureTime { get; private set; }
        
        public int Capacity { get; private set; }
        
        public Route Route { get; private set; }
        
        public Flight(DateTime departureTime, int capacity, Route route) {
            DepartureTime = departureTime;
            Capacity = capacity;
            Route = route;
        }
    }

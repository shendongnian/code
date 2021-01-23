    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    public class CityHub : Hub {
        // will be called from client side to send new city 
        // data to the client with drop down list
        public Task SendNewCity(string cityName) 
        {
            // dynamically typed method to update all clients
            return Clients.All.NewCityNotification(cityName);
        }
    }

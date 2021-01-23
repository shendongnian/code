    public class MyService : IMyService {
        public MyService(ExternalServiceClient serviceClient) {
            externalServiceClient = serviceclient;
        }
        public string GetName(Coordinate[] coordinates) {
            string name = string.Empty;
            name = externalServiceClient.GetInformationForCoordinates(coordinates);
            return name;
        }
        private readonly ExternalServiceClient externalServiceclient;
    }

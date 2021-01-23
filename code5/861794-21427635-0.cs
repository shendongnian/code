    class PeopleServiceClient : ServiceClient<IPeopleService>, IPeopleService {
        public Person[] Find(Person person) {
            // Delegate all responsability to the channel (which is connected to the API)
            return base.ServiceChannel.Find(person);
        }
    }

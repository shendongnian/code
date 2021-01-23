    public HouseController
    {
        private NotificationFacade _notificationFacade;
        public HouseController(NotificationFacade notificationFacade)
        {
            _notificationFacade = notificationFacade;
        }
        public void SomeActionMethod(int houseId)
        {
            _notificationFacade.NotifyUsersAboutPriceForHouse(houseId);
        }
    }       

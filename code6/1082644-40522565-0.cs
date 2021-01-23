    public class NotificationFacade
    {
        private IPriceService _priceService;
        private IHouseService _houseService;
        private IUserService _userService;
        private IEmailService _emailService;
        public NotificationFacade(IPriceService priceService, IHouseService houseService, IUserService userService, IEmailService emailService)
        {
            _priceService = priceService;
            _houseService = houseService;
            _userService = userService;
            _emailSerice = emailSerice;
        }
        public void NotifyUsersAboutPriceForHouse(int houseId)
        {
            var price = _priceService.GetHousePrice(houseId);
            var users = _houseService.GetUsersInHouse(houseId);
            foreach(var user in users)
            {
                var emailAddress = _userService.GetEmailOfUser(user);
                _emailService.SendEmailToAddress(emailAddress, "Your House Price is:" + price);
            }
         }
     }        

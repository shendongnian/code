    ExchangeUserData exchangeUserData = new ExchangeUserData();
    exchangeUserData.Username = "c-sharp";
    exchangeUserData.Password = "c-sharp"; // c-sharp's Password
    
    ExchangeService service = Service.ConnectToServiceWithImpersonation(exchangeUserData, impersonatedUserPrincipal);
    
    Contact contact = new Contact(service);
    
    // Specify the name and how the contact should be filed.
    contact.GivenName = "n.a.";
    contact.FileAsMapping = FileAsMapping.SurnameCommaGivenName;
    contact.DisplayName = "bau gmbh";
    
    // Specify the company name.
    contact.CompanyName = "bau";
    
    // Specify the business, home, and car phone numbers.
    contact.PhoneNumbers[PhoneNumberKey.BusinessPhone] = "00000 00000";
    contact.PhoneNumbers[PhoneNumberKey.MobilePhone] = "n.a.";
    contact.PhoneNumbers[PhoneNumberKey.BusinessFax] = "00000 00000";
    
    // Specify two email addresses.
    contact.EmailAddresses[EmailAddressKey.EmailAddress1] = new EmailAddress("e@mail.de");
    
    //homepage
    contact.BusinessHomePage = "n.a.";
    
    // Specify the home address.
    PhysicalAddressEntry paEntry1 = new PhysicalAddressEntry();
    paEntry1.Street = "straße";
    paEntry1.City = "stadt";
    paEntry1.State = "D";
    paEntry1.PostalCode = "88890";
    paEntry1.CountryOrRegion = "Deutschland";
    contact.PhysicalAddresses[PhysicalAddressKey.Home] = paEntry1;
    contact.Save();

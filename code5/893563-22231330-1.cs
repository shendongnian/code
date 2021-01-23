    //arrange
    var mockSiteRepository = new Mock<ISiteRepository>();
    var testForm = new Site { SiteID = 0 };
    Site savedSite = null;
    mockSiteRepository
        .Setup(repo => repo.Save(It.IsAny<Site>()))
        .Callback<Site>(s => savedSite = s);
    //act
    var controller = new SiteController(mockChemical.Object, mockSiteRepository.Object, mockChemicalRelationRepository.Object, mockAddressRepository.Object);
    var result = controller.Edit(testForm);
    //assert
    Assert.That(savedSite, Is.Not.Null); //this verifies that your setup was called
    Assert.That(savedSite.SiteID, Is.EqualTo(testForm.SiteID));
    Assert.That(savedSite.Name, Is.EqualTo(testForm.Name));
    //do your other asserts
    //always VerifyAll at the end so you know your setups were all called
    mockSiteRepository.VerifyAll();

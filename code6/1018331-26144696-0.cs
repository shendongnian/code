      var service = new PlusService(new BaseClientService.Initializer());
      var request = new PeopleResource.GetRequest(service, "114390708428853879348")
      {
          OauthToken = authParameters.AccessToken
      };
      Person person = request.Execute();
      Person.ImageData image = person.Image;
      string pictureUrl = image.Url;
      ... request to url here after munging sz

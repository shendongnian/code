    var requestCreateSection = new RestRequest(sectionCreateRoute, Method.POST);
    // use object initializer to make instance for body inline
    requestCreateSection.AddJsonBody(new NewSectionPostBody{
          Name="Test Section",
          Code=String.Empty,
          Description= new SectionContentType { Content="Test", Type="HTLM" }
          
    });
    valenceAuthenticator.Authenticate(client, requestCreateSection);

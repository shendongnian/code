    using Flurl.Http.Testing;
    ...
    [Test]
    public void ItemsExists_SuccessResponse() {
        // kick Flurl into test mode - all HTTP calls will be faked and recorded
        using (var httpTest = new HttpTest()) {
            // arrange
            test.RespondWith(200, "{status:'ok'}");
            // act
            sut.ItemExists("blah");
            // assert
            test.ShouldHaveCalled("http://your-url/*");
        }
    }

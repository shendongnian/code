    [Test]
    public void Add_PostIsValid_PostSlugIsUpdated()
    {
       var post = new Mock<Post>();
       post.Setup(x=>x.Title).Returns("Test");
    
       var myRepository = new MyRepository();
    
       myRepository.Add(post.Object);
    
       post.VerifySet(pst => pst.Slug = SlugConverter.Convert(post.Title));
    }

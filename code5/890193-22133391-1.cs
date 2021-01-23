    // gather the images into their respective entities, say Image1 and Image2 for an example
    var Image1 = new ImageEntity { // set the properties here };
    var Image2 = new ImageEntity { // set the properties here };
    var newItem = new ItemEntity
                  {
                      // set various scalar properties here
                      Images = {
                                   Image1, Image2
                               }
                  };
    var service = new ImageService();
    var addedEntity = service.AddItem(newItem); // adds and commits

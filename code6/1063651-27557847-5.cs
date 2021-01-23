    var collection = new NoteCollection(
                new Note {Text = "note 1"},
                new Note {Text = "note 2"},
                new Note {Text = "note 3"},
                new Note {Text = "note 4"});
    var pagedCollection = PagedCollectionFactory.GetAsPagedCollection<Note,NoteCollection>(1, 1, 1, collection);
    Assert.That(pagedCollection.CurrentPage, Is.EqualTo(1));
    Assert.That(pagedCollection.ToList().Count, Is.EqualTo(4));

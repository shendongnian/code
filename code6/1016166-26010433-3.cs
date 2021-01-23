    var obj = new List<Node>
    {
        new Node
        {
            type = "folder",
            name = "animals",
            path = "/animals",
            children = new List<Node>
            {
                new Node
                {
                    type = "folder",
                    name = "cat",
                    path = "/animals/cat",
                    children = new List<Node>
                    {
                        new Node
                        {
                            type = "folder",
                            name = "images",
                            path = "/animals/cat/images",
                            children = new List<Node>
                            {
                                new Node
                                {
                                    type = "file",
                                    name = "cat001.jpg",
                                    path = "/animals/cat/images/cat001.jpg"
                                  },
                                new Node {
                                    type = "file",
                                    name = "cat001.jpg",
                                    path = "/animals/cat/images/cat002.jpg"
                                }
                            }
                        }
                    }
                }
            }
        }
    };
    string json = Jil.JSON.Serialize(obj, Jil.Options.PrettyPrint);

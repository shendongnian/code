    var nodes = new []
     { 
        new Node { name = "name1" },
        new Node { name = "name2" }
     }
    nodeList.DisplayMember = "name";
    nodeList.DataSource = nodes;

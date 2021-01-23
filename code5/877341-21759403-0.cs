    TableCell tcTitle = new TableCell();
    TableCell tcStart = new TableCell();
    TableCell tcNew = new TableCell(); // create a new column Container
...  
    // populate it with the relevant content
    Literal litNew = new Literal();
    litNew.Text = "<div>New text here</div>";
    tcNew.Controls.Add(litNew);

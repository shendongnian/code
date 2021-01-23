    foreach(var s in doc.Descendants("server"))
    {
        var comment = s.PreviousNode as XComment;
        if (comment != null)
            Console.WriteLine(comment.Value); // outputs "Dummy servers"
    }
          

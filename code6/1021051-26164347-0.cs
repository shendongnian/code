    var str = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. 
    Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh 
    elementum imperdiet. Duis sagittis ipsum. Praesent mauris. 
    Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. 
    Class aptent taciti sociosqu ad litora torquent per conubia nostra, 
    per inceptos himenaeos. Curabitur sodales ligula in libero.";
    // str's length is much lower
    var bytes = new byte[510];
    Encoding.UTF8.GetBytes(str, 0, str.Length, bytes, 0);
    // Value of output is exactly the same as yours
    var output = Convert.ToBase64String(bytes);

    var regex = new Regex(@"^-*[0-9\.]+$");
    var m = regex.Match(text);
    if (m.Sucess)
        {
            Console.WriteLine("The input number is an integer.");
        }
        else
        {
            Console.WriteLine("The input number is not an integer.");
        }

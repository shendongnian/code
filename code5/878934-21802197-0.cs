    if (xdoc.Root.Elements().Any(el => el.Name.LocalName == "status"))
    {
        if (xdoc.Root.Element("status").Value == "ZERO_RESULTS")
        {
            // oops! no location found!
            Response.Write("That address does not exist");
        }
        else
        {
            // handle other status!
        }
    } 
    else if (xdoc.Root.Elements().Any(el => el.Name.LocalName == "result"))
    {
        //   var locationElement // rest of your code ...
    }
    else 
    {
        // another unknown response which you can have a default for
        Response.Write("Unknown error trying to get location for this address");
    }

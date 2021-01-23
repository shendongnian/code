    var gnomes = @"<GnomeArmy>
        <Gnome>
            <Name>Harry</Name>
            <Colour>Blue</Colour>
            <Children>
                <Child>Jessica</Child>
                <Child>Nick</Child>
            </Children>
        </Gnome>
        <Gnome>
            <Name>Mathew</Name>
            <Colour>Red</Colour>
            <Children>
                <Child>Lisa</Child>
                <Child>James</Child>
            </Children>
        </Gnome>
    </GnomeArmy>";
    
    var xdoc = XDocument.Parse(gnomes);
    
    Console.WriteLine (
        xdoc.Descendants("Gnome")
            .Select (parent => string.Format("{0} has these kids {1}", 
                                                 parent.Descendants("Name").First ().Value,
                                                 string.Join(", ", parent.Descendants("Child")
                                                                         .Select (child => child.Value)
                                                                                   )
                                             )
                     )
            );
    

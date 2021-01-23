    //Create new tool.
    RechthoekTool tool = new RechthoekTool();
    //Turn <Startpoint> and <Endpoint> into actual points
    var sp = Regex.Replace(xn["Startpunt"].InnerText, @"[\{\}a-zA-Z=]", "").Split(',');
    tool.startpunt = new Point(int.Parse(sp[0]), int.Parse(sp[1]));
    var ep = Regex.Replace(xn["Eindpunt"].InnerText, @"[\{\}a-zA-Z=]", "").Split(',');
    tool.eindpunt = new Point(int.Parse(ep[0]), int.Parse(ep[1]));
    //Set colour and width of brush
    string kleur = xn["Dikte"].InnerText;
    kleur.Replace(@"Color [", "");
    kleur.Replace(@"]", "");
    Color c = Color.FromName(kleur);
    tool.kwastkleur = c;
    tool.kwast = new SolidBrush(c);
    tool.dikte = int.Parse(xn["Dikte"].InnerText);
    List<RechthoekTool> s = new List<RechthoekTool>();  // You can now use your list.
    //Add to list
    s.listItems.Add(tool);

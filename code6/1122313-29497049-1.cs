    var input = JToken.Parse(jsonInput);
    var type = input["type"].ToObject<string>();
    if (type == "Gizmo")
    {
        var gizmo = input["value"].ToObject<Gizmo>();
    }
    else if (type == "Widget")
    {
        var widget = input["value"].ToObject<Widget>();
    }

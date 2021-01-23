    public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            var action = base.SelectAction(odataPath, controllerContext, actionMap);
            if (action == null)
            {
                if (odataPath.PathTemplate == "~/entityset/key/property")
                {
                    action = string.Format("Get{0}From{1}", odataPath.Segments[2].ToString(), odataPath.Segments[0].ToString());
                }
            }
            if (action != null)
            {
                var routeValues = odataPath.Segments.FirstOrDefault(x => x.SegmentKind == ODataRouteConstants.Key);
                if (routeValues != null)
                {
                    var keyRaw = routeValues.ToString();
                    var compoundKeyPairs = keyRaw.Split(',');
                    if (!compoundKeyPairs.Any())
                    {
                        return action;
                    }
                    foreach (var compoundKeyPair in compoundKeyPairs)
                    {
                        var pair = compoundKeyPair.Split('=');
                        if (pair.Length != 2)
                        {
                            continue;
                        }
                        var keyName = pair[0].Trim();
                        var keyValue = pair[1].Trim();
                        controllerContext.RouteData.Values.Add(keyName, keyValue);
                        //routeValues.Add(keyName, keyValue);
                    }
                }
            }
            return action;
        }

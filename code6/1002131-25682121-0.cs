    foreach(Shape geometryObj in ControlsOrWhatEver)
    {
        if(geometryObj  is Line || geometryObj  is Path || geometryObj  is Polypath)
        {
            pathList.Add(geometryObj);
        } 
        else
        {
            shapeList.Add(geometryObj);
        }
    }

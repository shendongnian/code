      foreach (var item in modelData.SurfaceTypeList)
                {
                    if (item.IsSelected)
                    {
                        var surfaceType = new XElement("SurfaceType");
                        var id = new XElement("Id");
                        id.Add(item.Value);
                        surfaceType.Add(id);
                        var i = id.Value;
                        surfaceTypeList.Add(surfaceType);
                    }
                }

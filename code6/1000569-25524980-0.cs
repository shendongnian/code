      var sceneGroup = e.Target.Parent;
      ILGroup plotcubeGroup = sceneGroup.Children.Where(item => item.Tag == "PlotCube").First() as ILGroup;
      ILGroup linePlotgroup = plotcubeGroup.Children.Where(item => item.Tag == "LinePlot").First() as ILGroup;
      if(group != null)
      {
      // continue with same logic as above
      }

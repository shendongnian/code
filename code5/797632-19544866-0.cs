          var textBox = new TextBox();
          var transformGroup = new TransformGroup()
              {
                  Children = new TransformCollection()
                      {
                          new MatrixTransform(), 
                          new TransformGroup
                          { 
                              Children = new TransformCollection()
                              {
                                  new ScaleTransform(), 
                                  new RotateTransform(), 
                                  new TranslateTransform()
                              }
                          }
                      }
              };
          textBox.RenderTransform = transformGroup;

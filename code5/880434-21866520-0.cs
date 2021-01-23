	var image = new Image
						{ 
							Height = 50,
							Width = 50,
							RenderTransform = new RotateTransform() 
							{ 
							Angle = 90, 
							CenterX = 25, //The prop name maybe mistyped 
							CenterY =25 //The prop name maybe mistyped 
							},
							Source = new BitmapImage(new Uri("MyImageSoruce"))
						};
	MainGrid.Children.Add(image);

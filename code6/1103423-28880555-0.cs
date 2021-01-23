        public void ponerMensaje(string mensaje, bool me)
        {
            Grid panelTexto = new Grid();
            Thickness marginpanel = panelTexto.Margin;
            marginpanel.Bottom = 10;
            panelTexto.Margin = marginpanel;
            //Create the colorBrush
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            //Create the triangle
            Polygon yellowTriangle = new Polygon();
            yellowTriangle.Fill = yellowBrush;
            //Create the triangle's points
            System.Windows.Point Point1 = new System.Windows.Point(0, 0);
            System.Windows.Point Point2 = new System.Windows.Point(10, 0);
            System.Windows.Point Point3;
            if (!me)
                Point3 = new System.Windows.Point(10, 10);
            else
                Point3 = new System.Windows.Point(0, 10);
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);
            //Add the points
            yellowTriangle.Points = polygonPoints;
            //Create the textblock
            Grid gridParaTexto = new Grid();// In WP TextBlocks haven't Backgroundcolor
            gridParaTexto.Background = yellowBrush;
            TextBlock texto = new TextBlock();
            texto.TextWrapping = TextWrapping.Wrap;
            texto.Text = mensaje;
            texto.Foreground = blackBrush;
            gridParaTexto.Children.Add(texto);
            panelTexto.Children.Add(yellowTriangle);
            panelTexto.Children.Add(gridParaTexto);
            //Add the message
            if (!me)
            {
                panelTexto.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = GridLength.Auto,
                });
                panelTexto.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star),
                });
                Grid.SetColumn(gridParaTexto, 1);
                Grid.SetColumn(yellowTriangle, 0);
                chat.Children.Add(panelTexto);
            }
            else
            {
                panelTexto.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star),
                });
                panelTexto.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = GridLength.Auto,
                });
                gridParaTexto.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                Grid.SetColumn(gridParaTexto, 0);
                Grid.SetColumn(yellowTriangle, 1);
                chat.Children.Add(panelTexto);
            }
        }

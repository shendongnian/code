            var myPolyline = new ESRI.ArcGIS.Client.Geometry.Polyline();
            for (int i = 0; i < 200000; i++)
            {
                myPolyline.Paths.Add(((ESRI.ArcGIS.Client.Geometry.Polyline)myGraphicsLayer.Graphics[i].Geometry).Paths[0]);
            }
            Graphic myGraph = new Graphic();
            myGraph.Geometry = myPolyline;
            ESRI.ArcGIS.Client.Symbols.SimpleLineSymbol sym = new ESRI.ArcGIS.Client.Symbols.SimpleLineSymbol();
            sym.Color = new SolidColorBrush(Colors.Red);
            sym.Width = 2;
            myGraph.Symbol = sym;
            myGraphicsLayer.Graphics.Add(myGraph);

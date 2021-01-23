     ... PrintDialog dialog = new PrintDialog();
            //dialog.PrintVisual(this.scrollCheckCardinfo, "");
            Nullable<Boolean> print = dialog.ShowDialog();
            if (print == true)
            {
                Grid DynamicGrid = new Grid();
                DynamicGrid.Margin = new Thickness(100, 50, 0, 0);
                RowDefinition gridRow1 = new RowDefinition();
                gridRow1.Height = new GridLength(45);
                RowDefinition gridRow2 = new RowDefinition();
                DynamicGrid.RowDefinitions.Add(gridRow1);
                DynamicGrid.RowDefinitions.Add(gridRow2);
                TextBlock txtBlock1 = new TextBlock();
                txtBlock1.Text = "Printed by xyz " + DateTime.Now.ToString();
                txtBlock1.FontSize = 14;
                txtBlock1.FontWeight = FontWeights.Bold;
                txtBlock1.VerticalAlignment = VerticalAlignment.Top;
                Grid.SetRow(txtBlock1, 0);
                Grid.SetRow(this.scrollCheckCardinfo, 1);
                DynamicGrid.Children.Add(txtBlock1);
                DynamicGrid.Children.Add(CloneXaml(this.scrollCheckCardinfo));
                dialog.PrintVisual(DynamicGrid, "xyz");
                
            }...
         public static T CloneXaml<T>(T source)
        {
            string xaml = XamlWriter.Save(source);
            StringReader sr = new StringReader(xaml);
            XmlReader xr = XmlReader.Create(sr);
            return (T)XamlReader.Load(xr);
        }

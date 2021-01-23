            foreach (Visio.Master master in doc.Masters)
            {
                string imageName = master.NameU;
                string imageFileName = Path.Combine(@"c:\temp", imageName);
                var selection = doc.Application.ActivePage.CreateSelection(Visio.VisSelectionTypes.visSelTypeEmpty);
                foreach (Visio.Shape shp in master.Shapes)
                    selection.Select(shp, (short)Visio.VisSelectArgs.visSelect);
                selection.Export(imageFileName + ".svg");
            }

                Doc pdf = new Doc();
                // adjust the default rotation and save
                double w = pdf.MediaBox.Width;
                double h = pdf.MediaBox.Height;
                double l = pdf.MediaBox.Left;
                double b = pdf.MediaBox.Bottom;
                // explicitly giving page size
                pdf.MediaBox.String = "A4";
                pdf.Transform.Rotate(90, l, b);
                pdf.Transform.Translate(w, 0);
                pdf.Rect.Width = h;
                pdf.Rect.Height = w;
		
		        int theID1 = pdf.GetInfoInt(pdf.Root, "Pages");
                pdf.SetInfo(theID1, "/Rotate", "90");
                int theID;
                pdf.Rect.String = "17 55 823 423";
                theID = pdf.AddImageHtml(html.ToString()); //Writes the HTML image to PDF

    PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                prnt.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                Size pageSize = new Size(prnt.PrintableAreaWidth + 30, prnt.PrintableAreaHeight + 300);
                PrntFrm.Measure(pageSize);
                PrntFrm.Arrange(new Rect(15, 15, pageSize.Height, pageSize.Width));
                prnt.PrintVisual(PrntFrm, "Job Card");
            }

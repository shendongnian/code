    PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                Size pageSize = new Size(prnt.PrintableAreaWidth - 30, prnt.PrintableAreaHeight - 30);
                PrntFrm.Measure(pageSize);
                PrntFrm.Arrange(new Rect(15, 15, pageSize.Width, pageSize.Height));
                prnt.PrintVisual(PrntFrm, "Work Request");
            }

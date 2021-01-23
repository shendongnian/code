        protected override void CreateChildControls()
        {
            Controls.Clear();
            //init controls
            buttonTbl = new Table();
            buttonPnl.ID = "buttonPnl";
            logoImg = new System.Web.UI.WebControls.Image();
            logoImg.ID = "logoImg";
            logoImg.Width = Unit.Percentage(100);//100% of cell width
            logoImg.Height = Unit.Percentage(100);//100% of cell width
            errorImg = new System.Web.UI.WebControls.Image();
            errorImg.ID = "errorImg";
            errorImg.Width = Unit.Percentage(50);//50% of cell width
            errorImg.Height = Unit.Percentage(50);//50% of cell height
            mainTextTb = new TextBox();
            mainTextTb.ID = "mainTextTb";
            mainTextTb.Text = "changed";
            mainTextTb.Font.Size = 20;
            mainTextTb.Width = Unit.Percentage(100);
            subTextLbl = new Label();
            subTextLbl.ID = "subTextLbl";
            subTextLbl.Text = "sub text";
            subTextLbl.Font.Size = 12;
            //format table
            buttonTbl.Width = 200;
            buttonTbl.Height = 150;
            buttonTbl.CellPadding = (int)Unit.Percentage(5).Value;
            //add the 3 rows
            buttonTbl.Rows.Add(imgRow);
            buttonTbl.Rows.Add(mainTextRow);
            buttonTbl.Rows.Add(subTextRow);
            //add the cells
            imgRow.Cells.Add(logoImgCell);
            imgRow.Cells.Add(errorImgCell);
            mainTextRow.Cells.Add(mainTextCell);
            subTextRow.Cells.Add(subTextCell);
            //add controls to their cells
            logoImgCell.Controls.Add(logoImg);
            errorImgCell.Controls.Add(errorImg);
            mainTextCell.Controls.Add(mainTextTb);
            subTextCell.Controls.Add(subTextLbl);
            //position cells
            logoImgCell.HorizontalAlign = HorizontalAlign.Right;
            logoImgCell.VerticalAlign = VerticalAlign.Top;
            errorImgCell.HorizontalAlign = HorizontalAlign.Right;
            errorImgCell.VerticalAlign = VerticalAlign.Top;
            mainTextCell.ColumnSpan = 2;
            subTextCell.ColumnSpan = 2;
            subTextCell.HorizontalAlign = HorizontalAlign.Right;
            this.Controls.Add(buttonTbl);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //render controls
            buttonTbl.RenderControl(writer);
        }

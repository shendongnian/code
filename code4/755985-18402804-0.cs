    Code39BarcodeDraw barcode39 = BarcodeDrawFactory.Code39WithoutChecksum;
               // Panel pnl = new Panel();
                Label str = new Label();
                str.Text="SER1012308131";
               // System.Drawing.Image img = barcode39.Draw("SER1012308131", 40);
                //string path = Server.MapPath("~/Uploads/") + img+".jpeg";
                string path = @"~/Uploads/abcd.jpeg";
              //  img.Save(path);
                Image imgg = new Image();
                imgg.ImageUrl=path;
                pnlpnl.Width = Unit.Pixel(300);
                pnlpnl.Height = Unit.Pixel(45);
                pnlpnl.Controls.Add(imgg);
                pnlpnl.Controls.Add(str);
                Session["ctrl"] = pnlpnl;
                ClientScript.RegisterStartupScript
                    (this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=45px,width=300px,scrollbars=1');</script>");

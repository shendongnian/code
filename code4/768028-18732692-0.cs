     if (e.Row.Cells[16].Text == "0")
                        {
                            e.Row.Cells[16].Text = string.Empty;
                        }
                        else
                        {
                            ImageButton img1 = new ImageButton();
                            img1.ImageUrl = "images/ablue.GIF";
                            img1.Height = 14;
                            img1.Width = 20;
                            img1.ToolTip = "Image Available";
                            img1.cssClass = "imageButtonClass";
                            img1.Attributes.Add("OnClick", "javascript:return SetId('" +     e.Row.Cells[2].Text.ToString() + "');");
                                e.Row.Cells[16].Controls.Add(img1);
                            }

                        List<SelectListItem> liFonts = new List<SelectListItem>();
                        liFonts.Add(new SelectListItem { Text = "nimbus-sans-condensed", Value = "nimbus-sans-condensed" });
                       //For now selecting only 10 fonts.
                        foreach (FontFamily font in System.Drawing.FontFamily.Families.Take(10))
                        {
                            liFonts.Add(new SelectListItem { Text = font.Name, Value = font.Name });
                        }
                        ViewBag.vFontlIst = liFonts;

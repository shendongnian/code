                    using (MemoryStream ms = new MemoryStream())
                    {
                        oBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] byteImage = ms.ToArray();
                        row["barcode"] = byteImage;
                    }
                    dataTable.Rows.Add(row);

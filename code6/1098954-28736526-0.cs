    public ActionResult GetReturnShippingLabel(int orderId, bool showFull)
            {
                string shippingLabel = new OrderRepository().GetOrderReturnShippingLabel(orderId);
                if (!string.IsNullOrEmpty(shippingLabel))
                {
                    byte[] bytes = Convert.FromBase64String(shippingLabel);
                    Image image = null;
                    MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
                    ms.Write(bytes, 0, bytes.Length);
                    image = Image.FromStream(ms, true);
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    if (!showFull)
                        image = image.GetThumbnailImage(326, 570, null, IntPtr.Zero);
                    ImageConverter converter = new ImageConverter();
                    byte[] imgArray = (byte[])converter.ConvertTo(image, typeof(byte[]));
                    return File(imgArray.ToArray(), "image/gif");
                }
                else
                {
                    return null;
                }
            }

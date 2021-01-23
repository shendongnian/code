               if (pic == null && imageData == null) //pictures are processed differently - they're an absolute s**t storm to code...
                {
                    runToAmend.InsertAfterSelf(item.CloneNode(true));
                }
                else
                {
                    if(pic != null)
                    {
                        runToAmend.InsertAfterSelf(CreateImageFromBlip(source, item, footerHeaderPart,pic));
                    }
                    else if (imageData != null)
                    {
                        runToAmend.InsertAfterSelf(CreateImageFromShape(source, item, footerHeaderPart, imageData));
                    }
                }

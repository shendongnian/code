    var savingThread = new Thread((ThreadStart)(() =>
                {
                    SignatureToImage obj = new SignatureToImage();
                    Bitmap bmp = obj.SigJsonToImage(signJson.Value);
                    SaveFileDialog dialog = new SaveFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {                                       
                        bmp.Save(dialog.FileName+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }));
                savingThread.SetApartmentState(ApartmentState.STA);
                savingThread.Start();
                savingThread.Join();

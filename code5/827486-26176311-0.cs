       private void DetectFaces()
        {
            try
            {
                Image<Gray, byte> grayframe = TestImage.Convert<Gray, byte>();
                //Assign user-defined Values to parameter variables:
                MinNeighbors = int.Parse(comboBoxMinNeigh.Text);  // the 3rd parameter
                WindowsSize = int.Parse(textBoxWinSiz.Text);   // the 5th parameter
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRte.Text); //the 2nd parameter
                //detect faces from the gray-scale image and store into an array of type 'var',i.e 'MCvAvgComp[]'
                var faces = grayframe.DetectHaarCascade(haar, ScaleIncreaseRate, MinNeighbors,
                                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                        new Size(WindowsSize, WindowsSize))[0];
                if (faces.Length > 0)
                {
                    MessageBox.Show("Total Faces Detected: " + faces.Length.ToString());
                    Bitmap BmpInput = grayframe.ToBitmap();
                    Bitmap ExtractedFace;  // an empty "box"/"image" to hold the extracted face.
                    Graphics FaceCanvas;
                    //Set The Face Number
                    //FaceCollection = Directory.GetFiles(@"Face Collection\", "*.bmp");
                    //int FaceNo = FaceCollection.Length;
                    //A Bitmap Array to hold the extracted faces
                    EXfaces = new Bitmap[faces.Length];
                    int i = 0;
                    //draw a green rectangle on each detected face in image
                    foreach (var face in faces)
                    {
                        //locate the detected face & mark with a rectangle
                        TestImage.Draw(face.rect, new Bgr(Color.Green), 3);
                        //set the size of the empty box(ExtractedFace) which will later contain the detected face
                        ExtractedFace = new Bitmap(face.rect.Width, face.rect.Height);
                        //set empty image as FaceCanvas, for painting
                        FaceCanvas = Graphics.FromImage(ExtractedFace);
                        //graphics draws the located face on the faceCancas, thus filling the empty ExtractedFace 
                        //image with exact pixels of the face to be extracted from input image
                        FaceCanvas.DrawImage(BmpInput, 0, 0, face.rect, GraphicsUnit.Pixel);
                        //save this extracted face to hard disk
                        //ExtractedFace.Save(@"Face Collection\" + "Face_" + (FaceNo++) + ".bmp");//save images in folder
                        //Save this extracted face to array
                        EXfaces[i] = ExtractedFace;
                        i++;
                    }
                    //Display the detected faces in imagebox
                    imageBox1.Image = TestImage;
                    MessageBox.Show(faces.Length.ToString() + " Face(s) Extracted sucessfully!");
                    imageBox2.Image = new Emgu.CV.Image<Bgr, Byte>(EXfaces[0]);
                    button3.Enabled = true;
                    textBox1.Enabled = true;
                }
                else
                    MessageBox.Show("NO faces Detected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }

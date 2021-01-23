        private void buttonClick(object sender, RoutedEventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                theInkCanvas.Strokes.Save(ms);
                var myInkCollector = new InkCollector();
                var ink = new Ink();
                ink.Load(ms.ToArray());
                using (RecognizerContext myRecoContext = new RecognizerContext())
                {
                    RecognitionStatus status;
                    myRecoContext.Strokes = ink.Strokes;
                    var recoResult = myRecoContext.Recognize(out status);
                    if (status == RecognitionStatus.NoError)
                    {
                        textBox1.Text = recoResult.TopString;
                        theInkCanvas.Strokes.Clear();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: " + status.ToString());
                    }
                }
            }
        }

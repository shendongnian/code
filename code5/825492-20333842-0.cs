        private int _numClicks = 0;
        // key = button-name, value = image file name
        private Dictionary<string, string> shuffled01 = new Dictionary<string, string>();
        ...
        shuffled01.Add(Btn1.Name, "file1");
        shuffled01.Add(Btn2.Name, "file2");
        private void OnBtnClick(object sender, RoutedEventArgs e)
        {
            _numClicks = ++_numClicks % 3; // replace 3 with the number of cases you require
            switch (_numClicks)
            {
                default:
                case 0:
                    Btn1.Background = Brushes.Bisque;
                    Btn2.Background = Brushes.Blue;
                    var imageFileName = shuffled01[Btn1.Name];
                    // blah
                    break;
                case 1:
                    Btn1.Background = Brushes.Chartreuse;
                    Btn2.Background = Brushes.Cornsilk;
                    // blah
                    break;
                case 2:
                    // blah
                    break;
            }
        }

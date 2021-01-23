                string pattern =
    @"^(?<p1>.*?)(?<c0>\w+)(?<s1>.*?)
    (?<p2>.*?)\k<c0>(?<s2>.*?)
    \k<p1>(?<c1>\w+)\k<s1>
    \k<p2>\k<c1>\k<s2>$";
    
                string text = 
    @"            if (forwardRadioButton.IsChecked.Value)
                    car = car.Forward(distance);
                else if (backwardRadioButton.IsChecked.Value)
                    car = car.Backward(distance);
                else if (forwardLeftRadioButton.IsChecked.Value)
                    car = car.ForwardLeft(distance);";
    
                var mc = Regex.Matches(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
    
                Console.WriteLine(mc.Count);
                Console.ReadKey();

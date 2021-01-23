        private string SelectText(IntPtr hWnd)
        {
            string text = string.Empty;
            Regex regex = new Regex(@"(\d{3}-\w{5,8})");
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT))
            {
                InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.MENU))
            {
                InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU);
            }
            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
            text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text) && regex.IsMatch(text))
            {
                Thread.Sleep(100);
                text.Trim();
                string[] textArr = text.Split(' ');
                text = textArr[textArr.Length - 1];
            }
            else
            {
                InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
                InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
                ClickOnPoint();
                Thread.Sleep(100);
                text = Clipboard.GetText();
                MatchCollection matchCollection = regex.Matches(text);
                if (matchCollection.Count > 0)
                {
                    text = matchCollection[0].Value;
                }
                else
                {
                    text = string.Empty;
                }
            }
            
            Clipboard.Clear();
            return text;
        }

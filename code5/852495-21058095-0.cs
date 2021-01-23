            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    WriteBlinkingText(blinkExit, 500, true);
                    WriteBlinkingText(blinkExit, 500, false);
                }
            });

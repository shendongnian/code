            private async Task EnterAfterDelay()
            {
                await Task.Delay(1000);
                SendKeys.Send("{ENTER}");
            }
            private void MyMethod()
            {
                EnterAfterDelay();
                MessageBox.Show("Hello!");
                Debug.Print("continue after a message box");
            }

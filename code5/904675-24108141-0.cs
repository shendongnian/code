    public class KeyboardStringReader
        {
            private KeyboardState currentKeyboardState;
            private KeyboardState oldKeyboardState;
    
            public string TextString { get; set; }
            public bool IsFinished { get; set; }
            public KeyboardStringReader()
            {
                TextString = string.Empty;
                IsFinished = false;
            }
    
            public void UpdateInput()
            {
                if (!this.IsFinished)
                {
                    oldKeyboardState = currentKeyboardState;
                    currentKeyboardState = Keyboard.GetState();
    
                    Keys[] pressedKeys;
                    pressedKeys = currentKeyboardState.GetPressedKeys();
    
                    foreach (Keys key in pressedKeys)
                    {
                        if (oldKeyboardState.IsKeyUp(key))
                        {
                            if (key == Keys.Back && TextString.Length > 0)
                            {
                                TextString = TextString.Remove(TextString.Length - 1, 1);
                            }
                            else if (key == Keys.Space)
                            {
                                TextString = TextString.Insert(TextString.Length, " ");
                            }
                            else if (key == Keys.Enter)
                            {
                                this.IsFinished = true;
                            } 
                            else
                            {
                                string keyString = key.ToString();
                                bool isUpperCase = ((Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock) &&
                                                     (!currentKeyboardState.IsKeyDown(Keys.RightShift) &&
                                                      !currentKeyboardState.IsKeyDown(Keys.LeftShift))) ||
                                                    (!Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock) &&
                                                     (currentKeyboardState.IsKeyDown(Keys.RightShift) ||
                                                      currentKeyboardState.IsKeyDown(Keys.LeftShift))));
    
                                if (keyString.Length == 1)
                                {
                                    TextString += isUpperCase ? keyString.ToUpper() : keyString.ToLower();
                                }
                            }
                        }
                    }
                }
            } 
        }

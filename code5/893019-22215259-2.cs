        private int count = 0;
        private string keysPressed = "NOTE";
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (count < keysPressed.Length)
            {
                if (e.Modifiers == (Keys)Enum.Parse(typeof(Keys), "None", true) &&
                    e.KeyCode == (Keys)Enum.Parse(typeof(Keys), keysPressed[count].ToString(), true))
                {
                    if (count == keysPressed.Length - 1)
                    {
                        MessageBox.Show(keysPressed);
                        //restart
                        count = 0;
                    }
                    else
                        count++;
                }
                else
                    count = 0;
            }
            else
                count = 0;
        }

     public Color[] newSequence(int length)
     {
            Color[] array = new Color[length];
            //Random rand = new Random(DateTime.Now.Millisecond);// don't inline w/ colors[] - wont be random
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                //array[i] = colors[rand.Next(0, 4)];
                if (textBox1.Text[i]=='R')
                {
                    array[i] = Color.Red;
                }
                else if (textBox1.Text[i] == 'G')
                {
                    array[i] = Color.Green;
                }
                else if (textBox1.Text[i] == 'B')
                {
                    array[i] = Color.Blue;
                }
                else if (textBox1.Text[i] == 'Y')
                {
                    array[i] = Color.Yellow;
                }
                else
                {
                    MessageBox.Show("Wrong colour input found!");
                }
            }
            //why stored to sequence? further use in current class?
            this.sequence = array;
            return array;
        }

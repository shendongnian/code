        if (!String.IsNullOrEmpty(textBoxFamily.Text))//Check if textBoxFamily is not empty.
        {
            Form1.family = textBoxFamily.Text;
            if (!String.IsNullOrEmpty(textBoxSize.Text))//Check if textBoxSize is not empty.
            {
                Form1.size = Convert.ToInt32(textBoxSize.Text);
                if (!String.IsNullOrEmpty(textBoxColor.Text))//Check if textBoxColor is not empty.
                {
                    Form1.color = textBoxColor.Text;
                    this.Close();//If everything happens correctly,close FontSettings.
                }
            }
        }

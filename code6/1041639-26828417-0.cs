            yourtextbox.TextChanged+= (s, e) =>
            {
                var textbox = s as TextBox;
                int value;
                if (int.TryParse(textbox.Text, out value))
                {
                    if (value > 255)
                        textbox.Text = "255";
                    else if (value < 0)
                        textbox.Text = "0";
                }
            }

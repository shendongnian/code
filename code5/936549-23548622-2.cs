    //split apart segments
    string[] split1 = textBox2.Text.Split(';');
    foreach (string segment in split1)
            {
                //split sub-segment
                string[] split2 = segment.Split(':');
                //check if it's valid
                if (split2.Count().Equals(2))
                {
                    textBox3.Text += String.Format("{0}{1}", split2[0].Trim(), Environment.NewLine);
                        textBox4.Text += String.Format("{0}{1}", split2[1].Trim(), Environment.NewLine);
                }
                else
                {
                    throw new ArgumentException("Invalid Segment");
                }
            }

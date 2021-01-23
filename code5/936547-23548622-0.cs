    string[] split1 = textBox2.Text.Split(';');
    foreach (string segment in split1)
            {
                if (!string.IsNullOrWhiteSpace(segment))
                {
                    string[] split2 = segment.Split(':');
                    if (split2.Count().Equals(2))
                    {
                        textBox3.Text += split2[0].Trim();
                        textBox4.Text += split2[1].Trim();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Segment");
                    }
                }
            }

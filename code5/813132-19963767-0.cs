    			for (int i = 0; i < Math.Max(MaxLen.Count, SeqIrregularities.Count); i++)
    			{
    				textBox1.Text += Environment.NewLine;
    				string text = String.Empty;
    				if (MaxLen.Count >= i)
    				{
    					text = MaxLen[i].ToString();
    				}
    				text.PadRight(30);
    				if (SeqIrregularities.Count >= i)
    				{
    					text += MaxLen[i].ToString();
    				}
    				textBox1.Text += text;
    			}

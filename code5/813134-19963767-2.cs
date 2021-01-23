			textBox1.Text = "Seq".PadRight(10) +  "MaxLen";
			for (int i = 0; i < Math.Max(MaxLen.Count, SeqIrregularities.Count); i++)
			{
				textBox1.Text += Environment.NewLine;
				string text = String.Empty;
				if (i < MaxLen.Count)
				{
					text = MaxLen[i].ToString();
				}
				text = text.PadRight(10);
				if (i < SeqIrregularities.Count)
				{
					text += SeqIrregularities[i];
				}
				textBox1.Text += text;
			}

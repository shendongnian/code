    for (int i = 0; i < listBox1.Items.Count; i++)
			{
				for (int j = i + 1; j < listBox1.Items.Count; j++)
				{
					if (listBox1.Items[i].ToString() == listBox1.Items[j].ToString())
					{
						Console.WriteLine("Duplicate {0}:{1}", listBox1.Items[i].ToString(), listBox1.Items[j].ToString());
					}
				}
			}

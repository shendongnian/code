    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    		{
    			if (e.KeyCode == Keys.Space)
    			{
    				String abc = this.richTextBox1.Text.Split(' ').Last();
    				if (abc == "while")
    				{
    					int stIndex = 0;
    					stIndex = richTextBox1.Find(abc, stIndex, RichTextBoxFinds.MatchCase);
    					richTextBox1.Select(stIndex, abc.Length);
    					richTextBox1.SelectionColor = Color.Aqua;
    					richTextBox1.Select(richTextBox1.TextLength, 0);
    					richTextBox1.SelectionColor = richTextBox1.ForeColor;
    				}
    			}
    		}

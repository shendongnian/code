      private void button7_Click(object sender, EventArgs e)
              {
                  if (seq1) 
                  {
                      textBox1.Text = " Seq"; // This guy doesn't showup in the textbox
                      foreach (object o in SeqIrregularities)
                      {
                          textBox1.Text += String.Join(Environment.NewLine, SeqIrregularities);
                      }
                  }
    
              }

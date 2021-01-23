    private void button1_Click(object sender, EventArgs e)
      {
         for (int i = 0; i <= listBox1.SelectedItems.Count - 1; i++) 
          {
               switch (listBox1 .Items [i].ToString ())
                    {
                        case "FirstForm":
                            Form2 frm2 = new Form2();
                            frm2.Show();
                            break;
                        case "SecondForm":
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break;
                        default:
                            break;
                   }
           }
      }

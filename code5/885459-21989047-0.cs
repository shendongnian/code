     private void button1_Click(object sender, EventArgs e)
                {
                    var sel = listBox1.SelectedItem;
                    Regex reg = new Regex(@"[0-9\.]+");
                      var res =   reg.Match(sel.ToString()); 
        
                }

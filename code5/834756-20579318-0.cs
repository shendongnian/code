     private void button1_Click(object sender, EventArgs e)
     {
                frm2 frmnew2 = new frm2();
                frmnew2.Id = Convert.ToInt32(TxtId.Text);
                frmnew2.EmpName = TxtName.Text;
                frmnew2.Add = TxtAdd.Text;
                this.Hide();
                frmnew2.Show();
     }

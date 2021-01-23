            DateTime d = DateTime.Now.AddHours(-5);
            DateTime d2 = Convert.ToDateTime("23.01.2013");
            if (d > d2){
                MessageBox.Show(d.ToString() + " " + d2.ToString());
            } else {
                MessageBox.Show("nope");
            }
